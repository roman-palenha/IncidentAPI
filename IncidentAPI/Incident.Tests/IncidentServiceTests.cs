using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business;
using Business.Services;
using Data.Data;
using Data.Entities;
using Data.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace IncidentAPI.Tests
{
    public class IncidentServiceTests
    {
        [Test]
        public async Task IncidentService_GetAll()
        {
            var expected = GetTestIncidents;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.IncidentRepository.GetAllAsync())
                .ReturnsAsync(GetTestIncidents.AsEnumerable());

            var incidentService = new IncidentService(mockUnitOfWork.Object,
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutomapperProfile()))));

            var actual = await incidentService.GetAllAsync();
            actual.Should().BeEquivalentTo(expected);
        }

        #region TestData

        public List<Guid> IDs =>
            new List<Guid>()
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };
            
        

        public List<Account> GetTestAccounts =>
            new List<Account>()
            {
                new Account()
                {
                    ContactId = IDs[2], Id = IDs[0],
                    Name = "TestAcc1", Incidents = new List<Incident>()
                    {
                        new Incident()
                        {
                            Description = "test description",
                            Name = "test incident"
                        }
                    }
                },
                new Account()
                {
                     ContactId = IDs[3], Id = IDs[1],
                    Name = "TestAcc2", Incidents = new List<Incident>()
                    {
                        new Incident()
                        {
                            Description = "test2 description",
                            Name = "test2 incident"
                        }
                    }
                }
            };

        public List<Contact> GetTestContacts =>
            new List<Contact>()
            {
                new Contact()
                {
                    Email = "abc@gmail.com", FirstName = "test1", LastName = "test11", Id = IDs[2],
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            Name = "TestAcc1"
                        }
                    }
                },
                new Contact()
                {
                    Email = "dfc@gmail.com", FirstName = "test2", LastName = "test21", Id = IDs[3],
                   
                }
            };

        public List<Incident> GetTestIncidents =>
            new List<Incident>()
            {
                new Incident()
                {
                    Description = "test description", Id = IDs[4],
                    Name = "test incident"
                },
                new Incident()
                {
                     Description = "test2 description", Id = IDs[5],
                    Name = "test2 incident"
                }
            };



        #endregion
    }
}
