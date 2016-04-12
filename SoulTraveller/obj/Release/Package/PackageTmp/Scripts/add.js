
var dbimgurl;

$('.csel').on('click', function () {
    $(this).addClass('active').siblings().removeClass('active');
    $('#Color').attr("color", $(this).css("background-color"));
});

$('#image').on('click', function () {
    $('#uploader').trigger("click");
});

$('#uploader').on('change', function () {
    console.log("changed");
    $('#form').ajaxSubmit({
        url: "/Soul/Upload",
        method: "post",
        data: $('.add').formSerialize(),
        success: function (data) {
            if(data.url==-1) return alert("图片不能大于2MB!");
            if(data.url==-2) return alert("图片格式只能是jpg,png,gif!");
            dbimgurl=data.url;
            $("#image").attr("src","/Images/" + data.url);
        }
    });
});

$('#btn-add').on('click', function () {
    var obj = {};

    var showType = $('#showtype').prop("checked");

    obj["Img"] = $('#image').attr("src");
    obj["Colors"] = $("#Color").attr("color");
    obj["Colors"] = $("#Color").attr("color");
    obj["ShowType"] = showType == true ? 1 : 0;


    $('.add').go(function (data) {
        alert(data.res);
    },obj);

});
