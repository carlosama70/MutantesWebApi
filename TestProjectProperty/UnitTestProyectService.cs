using DomainModel.DataTransfer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using TestProjectProperty.DataTransfer;

namespace TestProjectProperty
{
    [TestClass]
    public class UnitTestProyectService
    {
        [TestMethod]               
        public void EnviarLetrasInvalidas( )
        {
            dnaDt ResponseLoad = new dnaDt();
            string statusCode = string.Empty;

            string[] dna = new string[] { "uno", "do2", "tre", "cua" };

            var codigoDna = new
            {
                dna = dna
            };

            using (var httpClientHandler = new HttpClientHandler())

            {

                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var TestClient = new HttpClient(httpClientHandler))

                {
                    var carga = TestClient.PostAsync("https://localhost:44331/api/Mutante/mutant", codigoDna, new JsonMediaTypeFormatter()).Result;
                    // carga.EnsureSuccessStatusCode();
                    if( carga.ToString().IndexOf("500") != -1) 
                    {
                        statusCode = "500";
                    }                                                          
                }

            }
            Assert.AreEqual("500", statusCode );
        }

        [TestMethod]
        public void IngresaHumano()
        {
            dnaDt ResponseLoad = new dnaDt();
            string statusCode = string.Empty;

            string[] dna = new string[] { "ATGGGA", "CCTAGA", "TACTAT", "GGTAAG", "CGCTTA", "AGACTG" };

            var codigoDna = new
            {
                dna = dna
            };

            using (var httpClientHandler = new HttpClientHandler())

            {

                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var TestClient = new HttpClient(httpClientHandler))

                {
                    var carga = TestClient.PostAsync("https://localhost:44331/api/Mutante/mutant", codigoDna, new JsonMediaTypeFormatter()).Result;
                    // carga.EnsureSuccessStatusCode();
                    if (carga.ToString().IndexOf("500") != -1)
                    {
                        statusCode = "500";
                    }
                }

            }
            Assert.AreEqual("500", statusCode);
        }

        [TestMethod]
        public void IngresaMutante()
        {
            dnaDt ResponseLoad = new dnaDt();
            string statusCode = string.Empty;

            string[] dna = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            var codigoDna = new
            {
                dna = dna
            };

            using (var httpClientHandler = new HttpClientHandler())

            {

                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var TestClient = new HttpClient(httpClientHandler))

                {
                    var carga = TestClient.PostAsync("https://localhost:44331/api/Mutante/mutant", codigoDna, new JsonMediaTypeFormatter()).Result;
                    // carga.EnsureSuccessStatusCode();
                    if (carga.ToString().IndexOf("200") != -1)
                    {
                        statusCode = "200";
                    }
                }

            }
            Assert.AreEqual("200", statusCode);
        }

    }
}