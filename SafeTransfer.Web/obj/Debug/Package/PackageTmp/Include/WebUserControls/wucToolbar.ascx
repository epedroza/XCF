<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucToolbar.ascx.cs" Inherits="SafeTransfer.Web.Include.WebUserControls.wucToolbar" %>
<div style="float:right; width:280px;">
   <div style="border:solid 0px red; float:right; position:absolute; top:15px; width:280px;">
      <table border="0" cellpadding="0" cellspacing="0" style="width:280px; height:35px;">
         <tr style="vertical-align:top;">
            <td style="width:30px;">
               <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarSearch.png" onclick="imgSearch_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarBack.png" onclick="imgBack_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarNext.png" onclick="imgNext_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgNew" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarNew.png" onclick="imgNew_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarSave.png" onclick="imgSave_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgRelease" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarRelease.png" onclick="imgRelease_Click" />
            </td>
            <td style="width:5px;"></td>
            <td style="width:30px;">
               <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarDelete.png" onclick="imgDelete_Click" />
            </td>
         </tr>
      </table>
   </div>
</div>