using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Web.Helper
{
    public class CombosHelper : ICombosHelper
    {

        public CombosHelper()
        {
           
        }

        public IEnumerable<SelectListItem> GetComboTipoIdentificacion()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de Identificaion...]",
                Value = "0"
            });
            list.Insert(1, new SelectListItem
            {
                Text = "Cédula",
                Value = "Cédula"
            });
            list.Insert(2, new SelectListItem
            {
                Text = "Tarjata de Identidad",
                Value = "Tarjata de Identidad"
            });
            list.Insert(3, new SelectListItem
            {
                Text = "Pasaporte",
                Value = "Pasaporte"
            });
            list.Insert(4, new SelectListItem
            {
                Text = "Cédula de estrangeria",
                Value = "Cédula de estrangeria"
            });
            return list;
        }
    }
}
