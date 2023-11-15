using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prueba.Web.Helper
{
    public interface ICombosHelper
    {

        IEnumerable<SelectListItem> GetComboTipoIdentificacion();

    }
}
