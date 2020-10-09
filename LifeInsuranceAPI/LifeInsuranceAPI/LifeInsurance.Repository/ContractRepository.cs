using LifeInsurance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeInsurance.Repository
{
    public class ContractRepository : GenericRepository<Contracts>, IContractRepository
    {
        public ContractRepository(LifeInsuranceDbContext context) : base(context)
        {
        }

        /// <summary>
        /// /api/Contract/GetAll
        /// Get All specific Records from cotract table using parametrs
        /// </summary>
        /// <param name="search"></param>
        /// search by  customer name 
        /// <param name="sortCol"></param>
        /// sort by columns of contracts related data  eq. Id,customerName,CustomerGender ,
        /// <param name="sortDir"></param>
        /// sort by asc and desc
        /// <param name="skip"></param>
        /// how many records skip from db table.
        /// <param name="take"></param>
        /// how many records take from db table eq. 10 or 1000
        /// <returns>
        /// List of collection Contract
        /// </returns>
        public async Task<IEnumerable<Contracts>> GetAll(string search, string sortCol, string sortDir, int? skip, int? take)
        {
            var query = new List<Contracts>();
            if (!string.IsNullOrEmpty(search))
            {
                query = await _context.Contracts.Where(s => s.CustomerName.Contains(search) & !s.IsDeleted).ToListAsync();
            }
            else
                query = await _context.Contracts.Where(s => !s.IsDeleted).ToListAsync();

            if (skip != null && take != null)
            {
                query = query.Skip((int)skip).Take((int)take).ToList();
            }
            if (sortCol != null)
            {
                
                switch (sortCol.ToLower())
                {
                    case "id":
                        query = sortDir == "asc" ? query.OrderBy(s => s.Id).ToList() : query.OrderByDescending(s => s.Id).ToList();
                        break;
                    case "customername":
                        query = sortDir == "asc" ? query.OrderBy(s => s.CustomerName).ToList() : query.OrderByDescending(s => s.CustomerName).ToList();

                        break;
                    case "customergender":
                        query = sortDir == "asc" ? query.OrderBy(s => s.CustomerGender).ToList() : query.OrderByDescending(s => s.CustomerGender).ToList();
                        break;
                    case "customeraddress":
                        query = sortDir == "asc" ? query.OrderBy(s => s.CustomerAddress).ToList() : query.OrderByDescending(s => s.CustomerAddress).ToList();
                        break;
                    case "customercountry":
                        query = sortDir == "asc" ? query.OrderBy(s => s.CustomerCountry).ToList() : query.OrderByDescending(s => s.CustomerCountry).ToList();
                        break;
                    case "coverageplan":
                        query = sortDir == "asc" ? query.OrderBy(s => s.CoveragePlan).ToList() : query.OrderByDescending(s => s.CoveragePlan).ToList();
                        break;
                    default:
                        query = sortDir == "asc" ? query.OrderBy(s => s.AddedDate).ToList() : query.OrderByDescending(s => s.AddedDate).ToList();
                        break;
                }


            }
            return query;
        }
        /// <summary>
        /// for create new contract by using Create method 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        ///  return 1 if seccess else 0 
        ///  </returns>
        public async Task<int> Create(ContractModel model)
        {
            try
            {
                #region Coverage Plan
                var lstCountry = new List<string>();
                lstCountry.Add("USA");
                lstCountry.Add("CAN");
                var coveragePlanResponse = _context.CoveragePlans.Where(d => d.EligibilityCountry == (lstCountry.Any(k => k == model.CustomerCountry) ? model.CustomerCountry : "*") && (d.EligibilityDateFrom.Date <= model.SaleDate.Date && d.EligibilityDateTo.Date >= model.SaleDate.Date)).Include(ratechart => ratechart.RateChart).FirstOrDefault();
                #endregion
                if (coveragePlanResponse != null)
                {
                    #region  Calculate the age.
                    var rateChart = coveragePlanResponse.RateChart.Where(d => d.CustomerGender == model.CustomerGender).ToList();
                    var age = DateTime.Today.Year - model.DateofBirth.Year;
                    var rateChartResult = rateChart.Where(d => d.CustomerAge.Contains("<=") ? (age <= int.Parse(d.CustomerAge.Replace("<=", ""))) : (age > int.Parse(d.CustomerAge.Replace(">", "")))).ToList();

                    #endregion

                    var entity = new Contracts()
                    {
                        CustomerName = model.CustomerName,
                        CustomerAddress = model.CustomerAddress,
                        CustomerGender = model.CustomerGender,
                        CustomerCountry = model.CustomerCountry,
                        DateofBirth = model.DateofBirth,
                        SaleDate = model.SaleDate,
                        AddedDate = DateTime.Now,
                        IsDeleted = false,
                        CoveragePlan = coveragePlanResponse?.CoveragePlan,
                        NetPrice = rateChartResult.FirstOrDefault()?.NetPrice ?? 0
                    };
                    await _context.Contracts.AddAsync(entity);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// update the existing contract data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// return 1 if seccess else 0 
        /// </returns>
        public async Task<int> Update(ContractModel model)
        {
            try
            {
                #region Coverage Plan
                var lstCountry = new List<string>();
                lstCountry.Add("USA");
                lstCountry.Add("CAN");
                var coveragePlanResponse = _context.CoveragePlans.Where(d => d.EligibilityCountry == (lstCountry.Any(k => k == model.CustomerCountry) ? model.CustomerCountry : "*") && (d.EligibilityDateFrom.Date <= model.SaleDate.Date && d.EligibilityDateTo.Date >= model.SaleDate.Date)).Include(ratechart => ratechart.RateChart).FirstOrDefault();
                #endregion
                if (coveragePlanResponse != null)
                {
                    #region  Calculate the age.
                    var rateChart = coveragePlanResponse.RateChart.Where(d => d.CustomerGender == model.CustomerGender).ToList();
                    var age = DateTime.Today.Year - model.DateofBirth.Year;
                    var rateChartResult = rateChart.Where(d => d.CustomerAge.Contains("<=") ? (age <= int.Parse(d.CustomerAge.Replace("<=", ""))) : (age > int.Parse(d.CustomerAge.Replace(">", "")))).ToList();
                    #endregion
                    var entity = await _context.Contracts.FindAsync(model.Id);
                    if (entity != null)
                    {
                        entity.CustomerName = model.CustomerName;
                        entity.CustomerAddress = model.CustomerAddress;
                        entity.CustomerGender = model.CustomerGender;
                        entity.CustomerCountry = model.CustomerCountry;
                        entity.DateofBirth = model.DateofBirth;
                        entity.SaleDate = model.SaleDate;
                        entity.ModifiedDate = DateTime.Now;
                        entity.CoveragePlan = coveragePlanResponse?.CoveragePlan;
                        entity.NetPrice = rateChartResult.FirstOrDefault()?.NetPrice ?? 0;
                    }
                    _context.Contracts.Update(entity);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete record from db table . Its Update the Isdeleted =1 of selected id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            try
            {
                var contracts = await _context.Contracts.FindAsync(id);
                contracts.IsDeleted = true;
                _context.Contracts.Update(contracts);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}