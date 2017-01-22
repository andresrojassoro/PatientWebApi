var patient = {
    init: function () {
        this.get();
        this.loadBloodTypes();
        this.loadCountries();
    },
    get: function () {
        $("#patients").html("");
       $.ajax({
            type: "GET",
            dataType: "json",
            async: true,
            url: "http://localhost:60951/api/patient/get",
            success: function (data) {
                for (var i = 0; i < data.length ; i++)
                {
                    var obj = data[i];
                    $("#patients").append(
                        "<tr>" +
                        "<td>" + data[i].FirstName + "</td>" +
                        "<td>" + data[i].LastName + "</td>" +
                        "<td>" + data[i].IdNumber + "</td>" +
                        "<td>" + data[i].PhoneNumber + "</td>" +
                        "<td>" + data[i].DateofBirth + "</td>" +
                        "<td>" + data[i].Nationality.Name + "</td>" +
                        "<td>" + data[i].Diseases + "</td>" +
                        "<td>" + data[i].BloodType.Name + "</td>" +
                        "<td><a href='' onClick='patient.edit(" + data[i].PatientId + "); return false;'>Edit</a></td>" +
                        "<td><a href='' onClick='patient.remove(" + data[i].PatientId + "); return false;'>Delete</a></td>" +
                        "</tr>")
                }
            }
           
        });
    },
    save: function () {
        var obj = {
            PatientId: $('#txtPatientId').val(),
            FirstName: $('#txtFirstName').val(),
            LastName: $('#txtLastName').val(),
            IdNumber: $('#txtIdNumber').val(),
            DateofBirth: $('#txtDateOfBirth').val(),
            PhoneNumber: $('#txtPhoneNumber').val(),
            Diseases: $('#txtDiseases').val(),
            Nationality: { Id: $('#cmbCountries').val() },
            BloodType: { Id: $('#cmbBloodTypes').val() }
        };
        $.ajax({
            crossDomain: true,
            type: "POST",
            url: "http://localhost:60951/api/patient/save?JsonObj=" + JSON.stringify(obj) + "",
            //   data: JSON.stringify(patient),
            dataType: "json",
            context: document.body,
        }).success(function (data) {
            patient.get();
        });
    },
    edit: function (id) {
        $.ajax({
            type: "GET",
            dataType: "json",
            async: true,
            url: "http://localhost:60951/api/patient/get/"+id+"",
            success: function (data) {
                console.log(data);
                $("#txtPatientId").val(data[0].PatientId);
                $("#txtFirstName").val(data[0].FirstName);
                $("#txtLastName").val(data[0].LastName);
            },
            error: function (e, textStatus, errorThrown) {
                alert("ERROR");
            }
        });
    },
    remove: function (id) {
        $.ajax({
            type: "POST",
            dataType: "json",
            async: true,
            url: "http://localhost:60951/api/patient/delete/" + id + "",
            success: function (data) {
                patient.get();
            },
            error: function (e, textStatus, errorThrown) {
                alert("ERROR");
            }
        });
    },
    addNew: function () {
        $('#txtFirstName').val("");
        $('#txtLastName').val("");
        $('#txtPatientId').val("");
    },
    loadCountries: function () {
        $("#patients").html("");
        $.ajax({
            type: "GET",
            dataType: "json",
            async: true,
            url: "http://localhost:60951/api/patient/GetCountries",
            success: function (data) {
                for (var i = 0; i < data.length ; i++)
                {
                    var obj = data[i];
                    $("#cmbCountries").append("<option value='"+obj.Id+"'>"+obj.Name+"</option>")
                }
            }
           
        });
    },
    loadBloodTypes: function () {
        $("#patients").html("");
        $.ajax({
            type: "GET",
            dataType: "json",
            async: true,
            url: "http://localhost:60951/api/patient/GetBloodTypes",
            success: function (data) {
                for (var i = 0; i < data.length ; i++)
                {
                    var obj = data[i];
                    console.log(obj);
                    $("#cmbBloodTypes").append("<option value='" + obj.Id + "'>" + obj.Name + "</option>")
                }
            }
           
        });
    }
}