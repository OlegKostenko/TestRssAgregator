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
    public class RssRepositoryService : IEntityService<RssRepositoryDTO>
    {
        IGenericRepository<RssRepository> repository;
        readonly IMapper mapper;

        public RssRepositoryService(IGenericRepository<RssRepository> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<RssRepository, RssRepositoryDTO>()
                        .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                        .ForMember("Title", opt => opt.MapFrom(c => c.Title))
                        .ForMember("Description", opt => opt.MapFrom(c => c.Description))
                        .ForMember("CopyRight", opt => opt.MapFrom(c => c.CopyRight))
                        .ForMember("Link", opt => opt.MapFrom(c => c.Link))
                        .ForMember("Category", opt => opt.MapFrom(c => c.Category));

                cfg.CreateMap<RssRepositoryDTO, RssRepository>();
            }).CreateMapper();
        }

        public IEnumerable<RssRepositoryDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<RssRepositoryDTO>(a));
        }

        public RssRepositoryDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<RssRepositoryDTO>(repository.Get(id.Value));
        }

        public IEnumerable<RssRepositoryDTO> FindBy(Expression<Func<RssRepositoryDTO, bool>> predicate)
        {
            Expression<Func<RssRepository, bool>> expr = mapper.Map<Expression<Func<RssRepositoryDTO, bool>>, Expression<Func<RssRepository, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<RssRepositoryDTO>(a));
        }

        public void AddOrUpdate(RssRepositoryDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<RssRepository>(obj));
        }

        public void Delete(RssRepositoryDTO obj)
        {
            repository.Delete(mapper.Map<RssRepository>(obj));
        }
    }
}
