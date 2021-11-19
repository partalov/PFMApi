using PFMApi.Dto;
using AutoMapper;
using PFMApi.Database.Entity.TransactionsE;
using PFMApi.Database.Entity.CategoriesE;

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