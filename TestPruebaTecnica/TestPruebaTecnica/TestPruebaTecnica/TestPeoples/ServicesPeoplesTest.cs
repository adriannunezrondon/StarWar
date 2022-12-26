using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Services;
using Xunit;

namespace TestPruebaTecnica.TestPeoples
{
    public class ServicesPeoplesTest
    {
        [Fact]
        public async void GetPeoples_WhenCalled_RetunPeopleDTOResponse()
        {
            // Arrange 
            var peoples = new ServicesPeoples();
            var ListaOkResult = await peoples.GetListPeoples();
            // Act
            var value = (ListaOkResult.Result as OkObjectResult)?.Value as PeopleDTOResponse;
            //Assert
            Assert.IsType<PeopleDTOResponse>(value);
            Assert.IsType<OkObjectResult>(ListaOkResult.Result);

        }

    }



}
