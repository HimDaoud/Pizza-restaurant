using Losning_pizza_1_core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Losning_pizza_1_core.Controllers
{
    [Route("[controller]/[action]")]
    public class PizzaControllers:ControllerBase
    {
        private readonly PizzaContext _db;

        public PizzaControllers(PizzaContext db)
        {
            _db = db;
        }

        [HttpPost]
        public void SettInn(Pizza bestiltePizza)
        {
            var enBestilling = new Bestilling()
            {
                Antall = bestiltePizza.Antall,
                PizzaType = bestiltePizza.PizzaType,
                Tykkelse = bestiltePizza.Tykkelse
            };
            var funnetKunde = _db.Kunder.FirstOrDefault(k => k.Navn == bestiltePizza.Navn);
            if (funnetKunde== null)
            {
                var enKunde = new Kunde()
                {
                    Navn = bestiltePizza.Navn,
                    Adresse = bestiltePizza.Adresse,
                    Telefonnr = bestiltePizza.Telefonnr,
                };
                enKunde.Bestillinger = new List<Bestilling>();
                enKunde.Bestillinger.Add(enBestilling);
                _db.Kunder.Add(enKunde);
                _db.SaveChanges();
            }
            else
            {
                funnetKunde.Bestillinger.Add(enBestilling);
                _db.SaveChanges();
            }
        }
        public List<Pizza> HentAlle()
        {
            List<Kunde> alleKunder = _db.Kunder.ToList();
            List<Pizza> alleBestillinger = new List<Pizza>();
            foreach(var kunden in alleKunder)
            {
                foreach(var bestillingen in kunden.Bestillinger)
                {
                    var enBestilling = new Pizza()
                    {
                        Navn = kunden.Navn,
                        Adresse = kunden.Adresse,
                        Telefonnr = kunden.Telefonnr,
                        PizzaType = bestillingen.PizzaType,
                        Tykkelse = bestillingen.Tykkelse,
                        Antall = bestillingen.Antall
                    };
                    alleBestillinger.Add(enBestilling);
                }
            }
            return alleBestillinger;
        }
    }
}
