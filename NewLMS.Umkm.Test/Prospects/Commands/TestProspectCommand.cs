using FluentAssertions;
using FluentValidation;
using MediatR;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Prospects.Commands.PostProspects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Test.Prospects.Commands;
using static Testing;
using Assert = NUnit.Framework.Assert;

public class TestProspectCommand : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFieldNik()
    {
        var command = new ProspectPostCommand
        {
            AccountOfficer = "A000",
            Address = "JALAN DESA",
            BookingBranch = "0001",
            BranchId = "0001",
            City = "Bandung",
            CompanyId = "BO1",
            DateOfBirth = DateTime.Now,
            District = "Kiaracondong",
            Neighborhoods = "Babakan Sari",
            EstimateProcessDate = DateTime.Now,
            Fullname = "John Doe",
            Gender = Data.Enums.Gender.Male,
            MotherName = "Jane Doe",
            NoHandphone = "08112271271",
            NoIdentity = "11111111111111",
            PlaceOfBirth = "Unknown",
            
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

}

