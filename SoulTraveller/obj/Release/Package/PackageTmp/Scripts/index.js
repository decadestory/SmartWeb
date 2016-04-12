$(function () {

    $(document).on("click","img", function () {
        window.location.href = "/Soul/Detail/" + $(this).parent().parent().attr("sid");
    });

    var lock = false;

    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();
        var scrollHeight = $(document).height();
        var windowHeight = $(this).height();
        if (scrollTop + windowHeight == scrollHeight) {
            $('.loading').css("display", "block");
            var page = $('.container').attr("page");
            if (!lock) {
                lock = true;
                $.ajax({
                    url: "/Soul/GetPage",
                    type: "post",
                    data: { page: page },
                    success: function (res) {


                        var objs = eval(res);

                        if (objs.length == 0) {
                            $('.loading').html("已经到底啦！");
                            return lock = false;
                        }
                        else
                            $('.loading').css("display", "none");

                        setHtml(objs);

                        $('.container').attr("page", parseInt($('.container').attr("page")) + 1);
                        lock = false;
                    }
                });
            }
        }
    });

    function setHtml(objs) {
        for (var it in objs) {
            var html = '<article sid="' + objs[it].Id + '" class="item"><header style="background-color:' + objs[it].Colors + '">'
        + objs[it].Title + '</header><aside><img src="' + objs[it].Img + '"><input class="audiosrc" type="hidden" value="' + objs[it].Audio + '" />'
        + '<i class="fa fa-play-circle-o fa-3x playicon"></i></aside><footer><table><tr><td colspan="4" class="des">'
        + objs[it].Summary + '</td></tr><tr sid="' + objs[it].Id + '"><td><i class="fa fa-comments" comments> 评论(' + objs[it].Comment + ')</i></td><td><i class="fa fa-share-alt" shares> '
        + '分享(' + objs[it].Shared + ')</i></td><td><i class="fa fa-heart" views> 浏览(' + objs[it].Views + ')</i></td><td><i class="fa fa-thumbs-up" applaud> '
        + '赞(' + objs[it].Applaud + ')</i></td></tr></table></footer></article>';
            $('.container').append(html);
        }
    }

    $(document).on("click", "[applaud]", function () {
        var obj = $(this);
        $.ajax({
            url: "/Soul/Appauld",
            type: "post",
            data: { id: obj.parent().parent().attr("sid") },
            success: function (data) {
                obj.html(" 赞(" + data.cnt + ")");
            }
        });
    });


    $(document).on("click", "[shares]", function () {
        var obj = $(this);
        $.ajax({
            url: "/Soul/Shares",
            type: "post",
            data: { id: obj.parent().parent().attr("sid") },
            success: function (data) {
                obj.html(" 分享(" + data.cnt + ")");
            }
        });
    });

});