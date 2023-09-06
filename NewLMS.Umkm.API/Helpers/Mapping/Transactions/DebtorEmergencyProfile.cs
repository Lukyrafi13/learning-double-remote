using System;
using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorEmergencies;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
	public class DebtorEmergencyProfile:Profile
	{
		public DebtorEmergencyProfile()
		{
			CreateMap<DebtorEmergency, DebtorEmergencyResponse>();
		}
	}
}

