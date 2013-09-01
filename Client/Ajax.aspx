<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="Client.Ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body { font: 14px Arial; }
        table, td, th { border: solid 1px #ccc; }
        td, th { padding: 10px; }
        table { border-collapse: collapse; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tbAccounts">
        <thead>
            <tr>
                <th>
                    ID
                </th>
                <th>
                    Name
                </th>
                <th>
                    Operation
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <br />
    <table>
        <tr>
            <td>
                ID
            </td>
            <td>
                <input id="txtId" type="text" value="0" />
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                <input id="txtName" type="text" value="A" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input id="btnSave" type="button" value="Save" />
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsrender.min.js"></script>
    <script type="text/x-jsrender" id="tmplAccount">
    {{for #data}}
        <tr>
            <td>{{:Id}}</td>
            <td>{{:Name}}</td>
            <td>
                <a href="javascript:void(0);" onclick="EditData({{:Id}})">Edit</a>
                <a href="javascript:void(0);" onclick="DeleteData({{:Id}})">Delete</a>
            </td>
        </tr>
    {{/for}}
    </script>
    <script type="text/javascript">
        $(function () {
            BindData();

            $("#btnSave").click(function () {
                var id = $("#txtId").val();
                var name = $("#txtName").val();
                var data = { Id: id, Name: name };
                var type = "0" == id ? "POST" : "PUT";
                var url = "http://127.0.0.1:6001/Account/";
                if ("0" != id) {
                    url += id;
                }

                $.ajax({
                    url: url,
                    type: type,
                    cache: false,
                    data: JSON.stringify(data),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (data) {
                        BindData();
                    },
                    error: function (xhr) {
                        alert("error");
                    }
                });
            });
        });

        function DeleteData(id) {
            $.ajax({
                url: "http://127.0.0.1:6001/Account/" + id,
                type: "DELETE",
                cache: false,
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    BindData();
                },
                error: function (xhr) {
                    alert("error");
                }
            });
        }

        function EditData(id) {
            $.ajax({
                url: "http://127.0.0.1:6001/Account/" + id,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#txtId").val(data.Id);
                    $("#txtName").val(data.Name);
                },
                error: function (xhr) {
                    alert("error");
                }
            });
        }

        function BindData() {
            $.ajax({
                url: "http://127.0.0.1:6001/Account/",
                type: "GET",
                dataType: "json",
                success: function (data) {
                    var html = $("#tmplAccount").render(data);
                    $("#tbAccounts tbody").html(html);
                },
                error: function (xhr) {
                    alert("error");
                }
            });
        }
    </script>
    </form>
</body>
</html>
