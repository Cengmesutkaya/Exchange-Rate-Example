using Exchange_Rate_Example.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exchange_Rate_Example.Controllers
{
    public class HomeController : Controller
    {
        List<ExchangeRateModel> rateTypeList = new List<ExchangeRateModel>();

        public ActionResult Index()
        {
            using (WebClient wc = new WebClient())
            {
                var path = ConfigurationManager.AppSettings["urlApi"];
                var json = wc.DownloadString(path);
                dynamic parsed = JsonConvert.DeserializeObject(json);
                JsonToList(parsed);
            }
            return View(rateTypeList);
        }
        private void JsonToList(dynamic obj)
        {
            foreach (var result in obj)
            {
                foreach (var item in result)
                {
                    ExchangeRateModel rateType = new ExchangeRateModel();
                    rateType.RateTypeName = result.Name;
                    rateType.Names = item.isim;
                    rateType.Buying = item.alis;
                    rateType.Selling = item.satis;
                    rateType.Changing = (Convert.ToDecimal(item.degisim) / 100);
                    rateTypeList.Add(rateType);
                }
            }
        }
    }
}