﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieMaintenance.aspx.cs" Inherits="Training.Web.MovieMaintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintenance of the movie</title>
     <link href="dist/css/vendor/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/flat-ui.css" rel="stylesheet" />
    <script src="dist/js/vendor/jquery.min.js"></script>
    <script src="dist/js/flat-ui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="display:table; margin:20px auto">
        <div>
            <asp:GridView ID="MovieGridView" runat="server" AutoGenerateColumns="False"  Caption="Maintenance of the movie" 
                 OnRowCommand="MovieGridView_RowCommand"
                 OnRowDeleting="MovieGridView_RowDeleting"
                 OnRowDataBound="MovieGridView_RowDataBound"
                 OnRowUpdating="MovieGridView_RowUpdating"
                 OnRowEditing="MovieGridView_RowEditing"
                 OnRowCancelingEdit="MovieGridView_RowCancelingEdit"
                 OnPageIndexChanging="MovieGridView_PageIndexChanging" AllowPaging="True" PageSize="5">
                <PagerSettings NextPageText="下一页" PreviousPageText="前一页" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="MovieName" HeaderText="MovieName" SortExpression="MovieName" />
                    
                    <asp:BoundField DataField="TypeName" HeaderText="TypeName" SortExpression="TypeName" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ReadOnly="True" NullDisplayText="No image on file." AlternateText="Movie Image" >
                        <ControlStyle Height="100px" Width="150px" BorderStyle="Groove" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Actor" HeaderText="Actor" SortExpression="Actor" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" SortExpression="UploadDate" />
                    <asp:CheckBoxField DataField="IsAudit" HeaderText="IsAudit" SortExpression="IsAudit" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    <asp:CommandField AccessibleHeaderText="11" ShowEditButton="True" />
                    <asp:ButtonField ButtonType="Link" Text="UpdateButton" CommandName="UpdateButton" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    </body>
</html>
