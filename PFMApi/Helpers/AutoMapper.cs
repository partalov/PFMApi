using PFMApi.Dto;
using AutoMapper;
using PFMApi.Database.Entity;

namespace PFMApi.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Transactions, TransactionsDto>().ReverseMap();

			CreateMap<Categories, CategoriesDto>().ReverseMap();
		}
	}
}