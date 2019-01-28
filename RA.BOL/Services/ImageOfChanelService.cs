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
    public class ImageOfChanelService : IEntityService<ImageOfChanelDTO>
    {
        IGenericRepository<ImageOfChanel> repository;
        readonly IMapper mapper;

        public ImageOfChanelService(IGenericRepository<ImageOfChanel> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<ImageOfChanel, ImageOfChanelDTO>()
                        .ForMember("ImgId", opt => opt.MapFrom(c => c.ImgId))
                        .ForMember("ImgTitle", opt => opt.MapFrom(c => c.ImgTitle))
                        .ForMember("ImgLink", opt => opt.MapFrom(c => c.ImgLink))
                        .ForMember("ImgUrl", opt => opt.MapFrom(c => c.ImgUrl));

                cfg.CreateMap<ImageOfChanelDTO, ImageOfChanel>();
            }).CreateMapper();
        }

        public IEnumerable<ImageOfChanelDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<ImageOfChanelDTO>(a));
        }

        public ImageOfChanelDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<ImageOfChanelDTO>(repository.Get(id.Value));
        }

        public IEnumerable<ImageOfChanelDTO> FindBy(Expression<Func<ImageOfChanelDTO, bool>> predicate)
        {
            Expression<Func<ImageOfChanel, bool>> expr = mapper.Map<Expression<Func<ImageOfChanelDTO, bool>>, Expression<Func<ImageOfChanel, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<ImageOfChanelDTO>(a));
        }

        public void AddOrUpdate(ImageOfChanelDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<ImageOfChanel>(obj));
        }

        public void Delete(ImageOfChanelDTO obj)
        {
            repository.Delete(mapper.Map<ImageOfChanel>(obj));
        }
    }
}
