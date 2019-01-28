using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using RA.BOL.DTO;
using RA.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace RA.BOL.Services
{
    public class ItemService : IEntityService<ItemDTO>
    {
        IGenericRepository<Item> repository;
        readonly IMapper mapper;

        public ItemService(IGenericRepository<Item> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Item, ItemDTO>()
                        .ForMember("ItemId", opt => opt.MapFrom(c => c.ItemId))
                        .ForMember("Title", opt => opt.MapFrom(c => c.Title))
                        .ForMember("Link", opt => opt.MapFrom(c => c.Link))
                        .ForMember("Description", opt => opt.MapFrom(c => c.Description))
                        .ForMember("UpdateOn", opt => opt.MapFrom(c => c.UpdateOn))
                        .ForMember("ImgId", opt => opt.MapFrom(c => c.ImgId));

                cfg.CreateMap<ItemDTO, Item>();
            }).CreateMapper();
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<ItemDTO>(a));
        }

        public ItemDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<ItemDTO>(repository.Get(id.Value));
        }

        public IEnumerable<ItemDTO> FindBy(Expression<Func<ItemDTO, bool>> predicate)
        {
            Expression<Func<Item, bool>> expr = mapper.Map<Expression<Func<ItemDTO, bool>>, Expression<Func<Item, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<ItemDTO>(a));
        }

        public void AddOrUpdate(ItemDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<Item>(obj));
        }

        public void Delete(ItemDTO obj)
        {
            repository.Delete(mapper.Map<Item>(obj));
        }
    }
}
