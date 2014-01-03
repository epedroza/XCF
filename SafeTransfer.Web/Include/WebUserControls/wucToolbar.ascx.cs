/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucSelector_Cliente
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Web User Control que ayuda a filtrar una Cliente en particular
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;

namespace SafeTransfer.Web.Include.WebUserControls
{
   public partial class wucToolbar : System.Web.UI.UserControl
   {

      // Utilerías
      Function utilFunction = new Function();

      
      // Handlers

      public delegate void DelegateBackImage();
      public event DelegateBackImage ClickBackImage;

      public delegate void DelegateDeleteImage();
      public event DelegateDeleteImage ClickDeleteImage;

      public delegate void DelegateNewImage();
      public event DelegateNewImage ClickNewImage;

      public delegate void DelegateNextImage();
      public event DelegateNextImage ClickNextImage;

      public delegate void DelegateReleaseImage();
      public event DelegateReleaseImage ClickReleaseImage;

      public delegate void DelegateSaveImage();
      public event DelegateSaveImage ClickSaveImage;

      public delegate void DelegateSearchImage();
      public event DelegateSearchImage ClickSearchImage;


      // Propiedades

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Back</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de anterior</summary>
      public Boolean Enabled_Back
      {
         get { return this.imgBack.Enabled; }
         set
         {
            // Asignación del valor
            this.imgBack.Enabled = value;

            // Remover atributos
            this.imgBack.Attributes.Remove("onmouseout");
            this.imgBack.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgBack.Enabled){

               this.imgBack.ImageUrl = "~/Include/Image/Buttons/ToolbarBack.png";
               this.imgBack.Attributes.Add("onmouseout", "document.getElementById('" + this.imgBack.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarBack.png';");
               this.imgBack.Attributes.Add("onmouseover", "document.getElementById('" + this.imgBack.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarBack_Over.png';");

            }else{

               this.imgBack.ImageUrl = "~/Include/Image/Buttons/ToolbarBack_Disabled.png";

            }
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Delete</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de eliminar</summary>
      public Boolean Enabled_Delete
      {
         get { return this.imgDelete.Enabled; }
         set
         {
            
            // Asignación del valor
            this.imgDelete.Enabled = value;

            // Remover atributos
            this.imgDelete.Attributes.Remove("onmouseout");
            this.imgDelete.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgDelete.Enabled){

               this.imgDelete.ImageUrl = "~/Include/Image/Buttons/ToolbarDelete.png";
               this.imgDelete.Attributes.Add("onmouseout", "document.getElementById('" + this.imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarDelete.png';");
               this.imgDelete.Attributes.Add("onmouseover", "document.getElementById('" + this.imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarDelete_Over.png';");

            }else{

               this.imgDelete.ImageUrl = "~/Include/Image/Buttons/ToolbarDelete_Disabled.png";

            }

         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_New</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de nuevo</summary>
      public Boolean Enabled_New
      {
         get { return this.imgNew.Enabled; }
         set
         {
            
            // Asignación del valor
            this.imgNew.Enabled = value;

            // Remover atributos
            this.imgNew.Attributes.Remove("onmouseout");
            this.imgNew.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgNew.Enabled){

               this.imgNew.ImageUrl = "~/Include/Image/Buttons/ToolbarNew.png";
               this.imgNew.Attributes.Add("onmouseout", "document.getElementById('" + this.imgNew.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNew.png';");
               this.imgNew.Attributes.Add("onmouseover", "document.getElementById('" + this.imgNew.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNew_Over.png';");

            }else{

               this.imgNew.ImageUrl = "~/Include/Image/Buttons/ToolbarNew_Disabled.png";

            }

         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Next</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de siguiente</summary>
      public Boolean Enabled_Next
      {
         get { return this.imgNext.Enabled; }
         set
         {
            // Asignación del valor
            this.imgNext.Enabled = value;

            // Remover atributos
            this.imgNext.Attributes.Remove("onmouseout");
            this.imgNext.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgNext.Enabled){

               this.imgNext.ImageUrl = "~/Include/Image/Buttons/ToolbarNext.png";
               this.imgNext.Attributes.Add("onmouseout", "document.getElementById('" + this.imgNext.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNext.png';");
               this.imgNext.Attributes.Add("onmouseover", "document.getElementById('" + this.imgNext.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNext_Over.png';");

            }else{

               this.imgNext.ImageUrl = "~/Include/Image/Buttons/ToolbarNext_Disabled.png";

            }
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Release</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de liberar</summary>
      public Boolean Enabled_Release
      {
         get { return this.imgRelease.Enabled; }
         set
         {
            // Asignación del valor
            this.imgRelease.Enabled = value;

            // Remover atributos
            this.imgRelease.Attributes.Remove("onmouseout");
            this.imgRelease.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgRelease.Enabled){

               this.imgRelease.ImageUrl = "~/Include/Image/Buttons/ToolbarRelease.png";
			   this.imgRelease.Attributes.Add("onmouseout", "document.getElementById('" + this.imgRelease.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarRelease.png';");
               this.imgRelease.Attributes.Add("onmouseover", "document.getElementById('" + this.imgRelease.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarRelease_Over.png';");

            }else{

               this.imgRelease.ImageUrl = "~/Include/Image/Buttons/ToolbarRelease_Disabled.png";

            }
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Save</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de guardar</summary>
      public Boolean Enabled_Save
      {
         get { return this.imgSave.Enabled; }
         set 
         {
            // Asignación del valor
            this.imgSave.Enabled = value;

            // Remover atributos
            this.imgSave.Attributes.Remove("onmouseout");
            this.imgSave.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgSave.Enabled){

               this.imgSave.ImageUrl = "~/Include/Image/Buttons/ToolbarSave.png";
			      this.imgSave.Attributes.Add("onmouseout", "document.getElementById('" + this.imgSave.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSave.png';");
               this.imgSave.Attributes.Add("onmouseover", "document.getElementById('" + this.imgSave.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSave_Over.png';");

            }else{

               this.imgSave.ImageUrl = "~/Include/Image/Buttons/ToolbarSave_Disabled.png";

            }
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Enabled_Search</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de búsqueda</summary>
      public Boolean Enabled_Search
      {
         get { return this.imgSearch.Enabled; }
         set 
         {
            // Asignación del valor
            this.imgSearch.Enabled = value;

            // Remover atributos
            this.imgSearch.Attributes.Remove("onmouseout");
            this.imgSearch.Attributes.Remove("onmouseover");

            // Efectos en la imagen
            if (this.imgSearch.Enabled){

               this.imgSearch.ImageUrl = "~/Include/Image/Buttons/ToolbarSearch.png";
			      this.imgSearch.Attributes.Add("onmouseout", "document.getElementById('" + this.imgSearch.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSearch.png';");
               this.imgSearch.Attributes.Add("onmouseover", "document.getElementById('" + this.imgSearch.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSearch_Over.png';");

            }else{

               this.imgSearch.ImageUrl = "~/Include/Image/Buttons/ToolbarSearch_Disabled.png";

            }
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Back</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de anterior</summary>
      public String Tooltip_Back
      {
         get { return this.imgBack.ToolTip; }
         set { this.imgBack.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Delete</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de eliminar</summary>
      public String Tooltip_Delete
      {
         get { return this.imgDelete.ToolTip; }
         set { this.imgDelete.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_New</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de nuevo</summary>
      public String Tooltip_New
      {
         get { return this.imgNew.ToolTip; }
         set { this.imgNew.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Next</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de siguiente</summary>
      public String Tooltip_Next
      {
         get { return this.imgNext.ToolTip; }
         set { this.imgNext.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Release</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de liberar</summary>
      public String Tooltip_Release
      {
         get { return this.imgRelease.ToolTip; }
         set { this.imgRelease.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Save</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de guardar</summary>
      public String Tooltip_Save
      {
         get { return this.imgSave.ToolTip; }
         set { this.imgSave.ToolTip = value; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Tooltip_Search</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto desplegado cuando el puntero del mouse pasa por encima del botón de búsqueda</summary>
      public String Tooltip_Search
      {
         get { return this.imgSearch.ToolTip; }
         set { this.imgSearch.ToolTip = value; }
      }


      // Métodos publicos

      ///<remarks>
      ///   <name>wucToolbar.AddAttributes_Search</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Establece un atributo al botón de búsqueda de la barra de herramientas</summary>
      ///<param name="sAttributeKey">Llave del atributo a agregar</param>
      ///<param name="sAttributeValue">Valor del atributo</param>
      public void AddAttributes_Search(String sAttributeKey, String sAttributeValue){
         try
         {

            this.imgSearch.Attributes.Add(sAttributeKey, sAttributeValue);

         }catch (Exception ex){
            throw (ex);
         }
      }

      ///<remarks>
      ///   <name>wucToolbar.SetTooltip</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Establece un valor común a los Tooltip de los botones de la Toolbar</summary>
      ///<param name="Seed">Nombre común de Tooltip, ejemplo: PickUp</param>
      public void SetTooltip(String Seed){
         try
         {

            this.imgBack.ToolTip    = "Anterior " + Seed;
            this.imgDelete.ToolTip  = "Eliminar " + Seed;
            this.imgNew.ToolTip     = "Nuevo " + Seed;
            this.imgNext.ToolTip    = "Siguiente " + Seed;
            this.imgRelease.ToolTip = "Liberar " + Seed;
            this.imgSave.ToolTip    = "Guardar " + Seed;
            this.imgSearch.ToolTip  = "Buscar " + Seed;

         }catch (Exception ex){
            throw (ex);
         }
      }


      // Eventos del control

      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Lógica de la página
         try{

            // Atributos de los controles
            this.imgSearch.Attributes.Add("onmouseout", "document.getElementById('" + this.imgSearch.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSearch.png';");
            this.imgBack.Attributes.Add("onmouseout", "document.getElementById('" + this.imgBack.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarBack.png';");
            this.imgNext.Attributes.Add("onmouseout", "document.getElementById('" + this.imgNext.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNext.png';");
            this.imgNew.Attributes.Add("onmouseout", "document.getElementById('" + this.imgNew.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNew.png';");
            this.imgSave.Attributes.Add("onmouseout", "document.getElementById('" + this.imgSave.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSave.png';");
            this.imgRelease.Attributes.Add("onmouseout", "document.getElementById('" + this.imgRelease.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarRelease.png';");
            this.imgDelete.Attributes.Add("onmouseout", "document.getElementById('" + this.imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarDelete.png';");

            this.imgSearch.Attributes.Add("onmouseover", "document.getElementById('" + this.imgSearch.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSearch_Over.png';");
            this.imgBack.Attributes.Add("onmouseover", "document.getElementById('" + this.imgBack.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarBack_Over.png';");
            this.imgNext.Attributes.Add("onmouseover", "document.getElementById('" + this.imgNext.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNext_Over.png';");
            this.imgNew.Attributes.Add("onmouseover", "document.getElementById('" + this.imgNew.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarNew_Over.png';");
            this.imgSave.Attributes.Add("onmouseover", "document.getElementById('" + this.imgSave.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarSave_Over.png';");
            this.imgRelease.Attributes.Add("onmouseover", "document.getElementById('" + this.imgRelease.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarRelease_Over.png';");
            this.imgDelete.Attributes.Add("onmouseover", "document.getElementById('" + this.imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/ToolbarDelete_Over.png';");

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgBack_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickBackImage != null){ ClickBackImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgDelete_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickDeleteImage != null) { ClickDeleteImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgNew_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickNewImage != null) { ClickNewImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgNext_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickNextImage != null) { ClickNextImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgRelease_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickReleaseImage != null) { ClickReleaseImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgSave_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickSaveImage != null) { ClickSaveImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }
      
      protected void imgSearch_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickSearchImage != null) { ClickSearchImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

   }
}