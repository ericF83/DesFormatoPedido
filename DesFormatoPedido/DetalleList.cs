using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesFormatoPedido
{
    public class DetalleList
    {
        FRM_FormatoP frmFP = new FRM_FormatoP();

        public DetalleList(FRM_FormatoP frm)
        {
            this.frmFP = frm;
        }

        public List<Detalle> genera_pedid()
        {
            List<Detalle> ret = new List<Detalle>();
            Detalle DetalleVta = new Detalle();
            foreach (DataGridViewRow row in frmFP.dgvBottC.Rows)
            {
                if (row.Cells["CLASE"].Value.ToString() == "TOPS")
                {
                    
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column1"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString()  + "T100";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column1"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column2"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T101";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column2"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column3"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T102";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column3"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column4"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T103";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column4"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column5"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T104";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column5"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column6"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T105";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column6"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column7"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T106";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column7"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column8"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T107";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column8"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column9"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T108";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column9"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column10"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T109";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column10"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column11"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T110";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column11"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                }

                if (row.Cells["CLASE"].Value.ToString() == "BOTTOMS_D")
                {
                    
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column1"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T1";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column1"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column2"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T3";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column2"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column3"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T5";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column3"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column4"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T7";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column4"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column5"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T9";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column5"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column6"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T11";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column6"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column7"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T13";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column7"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column8"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T15";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column8"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column9"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T17";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column9"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column10"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T19";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column10"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column11"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T21";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column11"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column12"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T23";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column12"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column13"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T25";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column13"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                }

                if (row.Cells["CLASE"].Value.ToString() == "BOTTOMS_C")
                {
                    
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column1"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T28";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column1"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column2"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T29";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column2"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column3"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T30";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column3"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column4"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T31";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column4"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column5"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T32";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column5"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column6"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T33";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column6"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column7"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T34";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column7"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column8"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T36";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column8"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column9"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T38";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column9"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column10"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T40";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column10"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column11"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T42";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column11"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column12"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T44";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column12"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column13"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T46";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column13"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column14"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T48";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column14"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column15"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T50";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column15"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                }

                if (row.Cells["CLASE"].Value.ToString() == "UNIXES")
                {
                    
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells["Column1"].Value)))
                    {
                        DetalleVta = new Detalle();
                        DetalleVta.Articulo = row.Cells["sub"].Value.ToString();
                        DetalleVta.Modelo = row.Cells["Modelo"].Value.ToString();
                        DetalleVta.Estilo = row.Cells["Estilo"].Value.ToString();
                        DetalleVta.Color = row.Cells["Ncolor"].Value.ToString();
                        DetalleVta.Subcuenta = "C" + row.Cells["Ncolor"].Value.ToString() + "T999";
                        DetalleVta.Cantidad = Convert.ToInt32(row.Cells["Column1"].Value).ToString();
                        ret.Add(DetalleVta);
                    }
                }
            }
            return ret;
        }
    }
}
