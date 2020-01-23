using IntermediatorBotSample.EF.Models.Dto;
using IntermediatorBotSample.EF.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace IntermediatorBotSample.EF.Models.DataManager
{
    public class EndCustomerDataManager: IDataRepository<EndCustomer, EndCustomerDto>
    {
        private readonly VaaniContext _context;

        public EndCustomerDataManager(VaaniContext context)
        {
            _context = context;
        }
        public IEnumerable<EndCustomer> GetAll()
        {
            return _context.EndCustomer
                .ToList();
        }

        public EndCustomer Get(long id)
        {
            return _context.EndCustomer
                .SingleOrDefault(b => b.Id == id);
        }

        public EndCustomerDto GetDto(long id)
        {
            //using (var context = new VaaniContext())
            //{
                var endCustomer = _context.EndCustomer
                       .SingleOrDefault(b => b.Id == id);
                return EndCustomerDtoMapper.MapToDto(endCustomer);
            //}
        }
        public int Add(EndCustomer endCustomerEntity)

        {
            int result = -1;

            if (endCustomerEntity != null)
            {
                _context.EndCustomer.Add(endCustomerEntity);
                _context.SaveChanges();
                result = endCustomerEntity.Id;
            }
            return result;

        }

        public int Add(EndCustomerDto endCustomerEntity)

        {
            int result = -1;

            //if (endCustomerEntity != null)
            //{
            //    _context.EndCustomer.Add(endCustomerEntity);
            //    _context.SaveChanges();
            //    result = endCustomerEntity.Id;
            //}
            return result;

        }

        public int Update(EndCustomer endCustomerEntityToUpdate, EndCustomer endCustomerEntity)

        {
            int result = -1;

            if (endCustomerEntity != null)
            {
                _context.EndCustomer.Add(endCustomerEntity);
                _context.SaveChanges();
                result = endCustomerEntity.Id;
            }
            return result;

        }

        public int Delete(EndCustomer endCustomerEntity)

        {
            int result = -1;

            if (endCustomerEntity != null)
            {
                _context.EndCustomer.Add(endCustomerEntity);
                _context.SaveChanges();
                result = endCustomerEntity.Id;
            }
            return result;

        }

    }

}
