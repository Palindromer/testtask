$('#CitySelect').on('change', ChangeTbody);
$('#AgeSelect').on('change', ChangeTbody);


function ChangeTbody() {
    var city = $('#CitySelect').val();
    var ageSort = $('#AgeSelect').find(":selected").attr("value");
    $('#MyTbody').html("");

    $.get({
        url: '/api/users/',
        data: {
            city: city,
            ageSort: ageSort
        },
        success: function (userProfiles) {
            for (var i = userProfiles.length - 1; i >= 0; i--) {
                var tr = $("<tr>").prependTo("#MyTbody");
                $("<td>" + userProfiles[i].Age + "</td>").prependTo(tr);
                $("<td>" + userProfiles[i].City + "</td>").prependTo(tr);
                $("<td>" + userProfiles[i].Name + "</td>").prependTo(tr);
            }
        },
        dataType: "json"
    });
}