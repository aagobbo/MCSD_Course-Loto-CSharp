using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mind.Loteria.Dominio;
using System.Linq;

namespace Mind.Loteria.Tests.Unit
{
    [TestClass]
    public class MegaSpec
    {
        [TestMethod]
        public void DeveSortearNumeros()
        {
            //Arrange
            var gerador = new GeradorMegaSena();
            var mega = new Mega(gerador);

            //Act
            mega.Sortear();

            //Assert
            Assert.IsNotNull(mega.NumerosSorteados);
            Assert.AreEqual(mega.NumerosSorteados.Length, 6);

            var outOfRange = mega.NumerosSorteados.FirstOrDefault(i => i < 1 || i > 60);
            Assert.IsNotNull(outOfRange);
        }

        [TestMethod]
        public void DeveSortearNumerosDistintos()
        {
            //Arrange
            var gerador = new GeradorMegaSena();
            var mega = new Mega(gerador);

            //Act
            mega.Sortear();

            //Assert
            var distintos = mega.NumerosSorteados.Distinct();
            Assert.AreEqual(distintos.Count(), 6);

        }

        [TestMethod]
        public void DeveIdentificarVencedores()
        {
            //Arrange
            var mock = new GeradorNumerosMock();
            var mega = new Mega(mock);

            //Act
            mega.Sortear();
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 6 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 6 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 7 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 8 });

            //Assert
            Assert.AreNotEqual(mega.ListarVencedores().Count(), 0);
        }

        [TestMethod]
        public void DeveIdentificarPerdedores()
        {
            //Arrange
            var mock = new GeradorNumerosMock();
            var mega = new Mega(mock);

            //Act
            mega.Sortear();
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 6 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 6 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 7 });
            mega.AddBilhete(new int[] { 1, 2, 3, 4, 5, 8 });

            //Assert
            Assert.AreNotEqual(mega.ListarPerdedores().Count(), 0);
        }
    }
}
