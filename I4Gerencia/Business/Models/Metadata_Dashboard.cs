using System.ComponentModel.DataAnnotations;

namespace I4Gerencia.Business.Models;
public partial class Metadata_Dashboard : BaseModel
{
    public int dash_id { get; set; }
    public string suc_id { get; set; }
    public string dash_cod { get; set; }
    public string dash_nom { get; set; }
    public string dash_sql { get; set; }
    public string dash_frm { get; set; }
    public string dash_datos { get; set; }
    public int dash_tipo { get; set; }
    public bool dash_inact { get; set; }
    public string dash_usuar { get; set; }
    public Metadata_DashBoardUser dash_board { get; set; }
}