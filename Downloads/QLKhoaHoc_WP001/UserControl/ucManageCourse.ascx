<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucManageCourse.ascx.cs" Inherits="de1.UserControl.ucManageCourse" %>
<style type="text/css">
    .auto-style1 {
        height: 28px;
    }
    .auto-style2 {
        height: 29px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td>Course name:</td>
        <td><asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">Duration</td>
        <td class="auto-style1">
            <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox></td>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td>Category</td>
        <td><asp:DropDownList ID="DropDownListCategory" runat="server"></asp:DropDownList></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
    <td>Description</td>
    <td>
        <asp:TextBox ID="TextBoxDescription" TextMode="MultiLine" runat="server"></asp:TextBox></td>
       
    <td>&nbsp;</td>
</tr>
    <tr>
     <td class="auto-style2">Picture</td>
     <td class="auto-style2">
         <asp:FileUpload ID="FileUploadPicture" runat="server" /></td>
     <td class="auto-style2"></td>
 </tr>

    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="ButtonAddNew" runat="server" Text="Add new"  /></td>
    </tr>
</table>







<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="EntityDataSource1" AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="No." ReadOnly="True" SortExpression="ID" />
        <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Width ="100px" Height="100px" ImageUrl='<%# "~/images/Courses/" + Eval("ImageFilePath")%>' /><br />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
       <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" Text="Delete" />
    </ItemTemplate>
</asp:TemplateField>    
        <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="Edit" />
    </ItemTemplate>
</asp:TemplateField>
       
    </Columns>

</asp:GridView>








<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=QLKhoaHocEntities" DefaultContainerName="QLKhoaHocEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Courses">
</asp:EntityDataSource>









