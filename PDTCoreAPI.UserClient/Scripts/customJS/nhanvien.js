
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/NhanVien/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.MaNhanVien + '</td>';
                html += '<td>' + item.HoTenNhanVien + '</td>';
                html += '<td>' + item.DiaChi + '</td>';
                html += '<td>' + item.PhongBan + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + "'" + item.ID + "'" + ');">Edit</a> | <a href="#" onclick="Delele(' + "'" + item.ID + "'" + ');">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var nvObj = {
        ID: $('#ID').val(),
        MaNhanVien: $('#MaNhanVien').val(),
        HoTenNhanVien: $('#HoTenNhanVien').val(),
        DiaChi: $('#DiaChi').val(),
        PhongBan: $('#PhongBan').val()
    };
    $.ajax({
        url: "/NhanVien/InsertOrUpdate",
        data: JSON.stringify(nvObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(ID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
    $.ajax({
        url: "/NhanVien/GetNhanVien/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#MaNhanVien').val(result.MaNhanVien);
            $('#HoTenNhanVien').val(result.HoTenNhanVien);
            $('#DiaChi').val(result.DiaChi);
            $('#PhongBan').val(result.PhongBan);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var nvObj = {
        ID: $('#ID').val(),
        MaNhanVien: $('#MaNhanVien').val(),
        HoTenNhanVien: $('#HoTenNhanVien').val(),
        DiaChi: $('#DiaChi').val(),
        PhongBan: $('#PhongBan').val(),
    };
    $.ajax({
        url: "/NhanVien/InsertOrUpdate",
        data: JSON.stringify(nvObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#MaNhanVien').val("");
            $('#HoTenNhanVien').val("");
            $('#DiaChi').val("");
            $('#PhongBan').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Bạn có chắc chắn muốn xoá nhân viên đang chọn?");
    if (ans) {
        $.ajax({
            url: "/NhanVien/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

 
function preAddNew() {
    $('#ID').val("");
    $('#MaNhanVien').val("");
    $('#HoTenNhanVien').val("");
    $('#DiaChi').val("");
    $('#PhongBan').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#MaNhanVien').css('border-color', 'lightgrey');
    $('#HoTenNhanVien').css('border-color', 'lightgrey');
    $('#DiaChi').css('border-color', 'lightgrey');
    $('#PhongBan').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#MaNhanVien').val().trim() == "" || $('#MaNhanVien').val().length > 50) {
        $('#MaNhanVien').css('border-color', 'Red');
        if ($('#MaNhanVien').val().trim() == "") {
            $('#MaMessage').text('Mã nhân viên không được để trống !');
        }
        if ($('#MaNhanVien').val().length > 50) {
            $('#MaMessage').text('Mã nhân viên tối đa 50 kí tự !');
        }
        isValid = false;
    }
    else {
        $('#MaNhanVien').css('border-color', 'lightgrey');
        $('#MaMessage').text('');
    }


    if ($('#HoTenNhanVien').val().trim() == "" || $('#HoTenNhanVien').val().length > 100) {
        $('#HoTenNhanVien').css('border-color', 'Red');
        if ($('#HoTenNhanVien').val().trim() == "") {
            $('#TenMessage').text('Họ tên nhân viên không được để trống !');
        }
        if ($('#HoTenNhanVien').val().length > 50) {
            $('#TenMessage').text('Họ tên nhân viên tối đa 100 kí tự !');
        }
        isValid = false;
    }
    else {
        $('#HoTenNhanVien').css('border-color', 'lightgrey');
        $('#TenMessage').text('');
    }


    if ($('#DiaChi').val().length > 500) {
        $('#DiaChi').css('border-color', 'Red');
        if ($('#DiaChi').val().length > 500) {
            $('#DCMessage').text('Địa chỉ tối đa 500 kí tự !');
        }
        isValid = false;
    }
    else {
        $('#DiaChi').css('border-color', 'lightgrey');
        $('#DCMessage').text('');
    }


    if ($('#PhongBan').val().trim() == "" || $('#PhongBan').val().length > 50) {
        $('#PhongBan').css('border-color', 'Red');
        if ($('#PhongBan').val().trim() == "") {
            $('#PBMessage').text('Phòng ban không được để trống !');
        }
        if ($('#PhongBan').val().length > 50) {
            $('#PBMessage').text('Phòng ban tối đa 100 kí tự !');
        }
        isValid = false;
    }
    else {
        $('#PhongBan').css('border-color', 'lightgrey');
        $('#PBMessage').text('');
    }
    return isValid;
}