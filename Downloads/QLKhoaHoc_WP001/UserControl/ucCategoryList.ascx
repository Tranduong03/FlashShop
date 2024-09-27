<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoryList.ascx.cs" Inherits="de1.UserControl.ucCategoryList" %>
<asp:DataList ID="DataList1" runat="server" DataSourceID="EntityDataSource1">

    <ItemTemplate>
        
        <asp:HyperLink ID="HyperLink1" runat="server"  Text='<%# Eval("CatName") + "("+ Eval("Courses.Count")+")" %>' NavigateUrl='<%# "~/Course.aspx?CatID=" + Eval("CatID")%>' ></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=QLKhoaHocEntities" DefaultContainerName="QLKhoaHocEntities" EnableFlattening="False" EntitySetName="Categories" Include="Courses">
</asp:EntityDataSource>

