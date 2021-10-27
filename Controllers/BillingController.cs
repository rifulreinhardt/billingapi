using billingapi.Models;
using billingapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace billingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly BillingService _billingService;

        public BillingController(BillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        public ActionResult<List<Billing>> Get() =>
            _billingService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Billing> Get(string id)
        {
            var billing = _billingService.Get(id);

            if (billing == null)
            {
                return NotFound();
            }

            return billing;
        }

        [HttpPost]
        public ActionResult<Billing> Create(Billing billing)
        {
            _billingService.Create(billing);

            return CreatedAtRoute("GetBilling", new { id = billing.Id.ToString() }, billing);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Billing billingIn)
        {
            var billing = _billingService.Get(id);

            if (billing == null)
            {
                return NotFound();
            }

            _billingService.Update(id, billingIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var billing = _billingService.Get(id);

            if (billing == null)
            {
                return NotFound();
            }

            _billingService.Remove(billing.Id);

            return NoContent();
        }
    }
}
