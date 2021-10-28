using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShopBackEnd
{
  public static  class Accessor
  {
        public static ObservableCollection<ManufacturerViewAllResult> ManufacturereViewAll( )
        {
            ObservableCollection<ManufacturerViewAllResult> returnObj = new ObservableCollection<ManufacturerViewAllResult>();
            try
            {

                MedicalShopDataContext dc = new MedicalShopDataContext();
                dc.CommandTimeout = 0;
                var result = dc.ManufacturerViewAll();

                foreach (var item in result)
                {
                    returnObj.Add(item);
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex);
            }
            return returnObj;
        }
        public static ObservableCollection<ProductViewByManufactureIdResult> ProductViewByManufactureId(string id)
        {
            ObservableCollection<ProductViewByManufactureIdResult> returnObj = new ObservableCollection<ProductViewByManufactureIdResult>();
            try
            {

                MedicalShopDataContext dc = new MedicalShopDataContext();
                dc.CommandTimeout = 0;
                var result = dc.ProductViewByManufactureId(id);

                foreach (var item in result)
                {
                    returnObj.Add(item);
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex);
            }
            return returnObj;
        }
        public static ObservableCollection<ProductViewAllByManufactureIdResult> ProductViewAllByManufactureId(string id)
        {
            ObservableCollection<ProductViewAllByManufactureIdResult> returnObj = new ObservableCollection<ProductViewAllByManufactureIdResult>();
            try
            {

                MedicalShopDataContext dc = new MedicalShopDataContext();
                dc.CommandTimeout = 0;
                var result = dc.ProductViewAllByManufactureId(id);

                foreach (var item in result)
                {
                    returnObj.Add(item);
                }
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex);
            }
            return returnObj;
        }
    }
}
