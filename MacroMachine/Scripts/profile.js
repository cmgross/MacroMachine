$(document).ready(function () {
    $("#birthdayPicker").birthdayPicker();
    //set id of generated hidden field to ApplicationUser_Birthday on before submit
    //$(this).attr('id',   this.id + '_' + new_id);
    //$(this).attr('name', this.name + '_' + new_id)
    //birthDay

    $("#editProfile").submit(function () {
        var hdnBday = $(".birthDay");
        //var month = $("#myselect").val();
        //var day = $("#myselect").val();
        //var year = $("#myselect").val();
        hdnBday.attr("id", "ApplicationUser_Birthday");
        return true; // return false to cancel form action
    });
});

//https://github.com/rithychhen88/birthday-picker