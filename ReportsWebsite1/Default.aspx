<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home- Chigo aspx first</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5 shadow p-4 round bg-light w-75">
    <h2 class="mb-4 text-center text-info"> Student Registration</h2>

        <input type="hidden" id="hdnId" runat="server" />
        <div class="mb-3">
            <label for="txtName" class="form-label"> Full Name:</label>
            <input type="text" id="txtName" runat="server" class="form-control" placeholder="Full Name" required="" />
           
        </div>
        <div class="mb-3">
            <label for="txtAge" class="form-label">Age</label>
            <input type="number" id="txtAge" runat="server" class="form-control" min="10" max="20" required="" placeholder="Enter Age" />

        </div>

        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="Enter Email" required="" />
        </div>
       
        <div class="d-grid gap-2 col-6 mx-auto">

  <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />

</div>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold"></asp:Label>
        <asp:Gridview ID="Grideviewstudent" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped mt-4"
            DataKeyNames="studentId"
            OnRowEditing="Grideviewstudent_RowEditing"
            OnRowDeleting="Grideviewstudent_RowDeleting">
            <Columns>
                <asp:BoundField DataField="studentId" HeaderText="Student ID" ReadOnly="true" />
                <asp:BoundField DataField="FullName" HeaderText="Student Name's" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
           
        </asp:Gridview> 
    </form>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</body>
</html>
