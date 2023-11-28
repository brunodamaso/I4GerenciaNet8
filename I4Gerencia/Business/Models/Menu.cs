namespace I4Gerencia.Business.Models;

public class Menu
{
    public string Titulo { get; set; }
    public List<SubMenu> SubMenus { get; set; }
}

public class SubMenu
{
    public string Nombre { get; set; }
    public bool HasDashBoard { get; set; }
}
