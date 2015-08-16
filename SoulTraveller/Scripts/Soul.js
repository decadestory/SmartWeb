$(function () {

    function status2play(obj, flag) {
        if (flag == 1) { //转成正在播放状态图标
            $('.fa-pause').addClass("fa-play-circle-o fa-3x");
            $('.fa-pause').removeClass('fa-pause fa-2x');

            obj.removeClass("fa-play-circle-o fa-3x");
            obj.addClass("fa-pause fa-2x");
            $(".audiosrc").removeAttr('isplaying');

            audio.addEventListener('ended', function () {
                status2play(obj, 0);
            }, false);


        } else if (flag == 0) { //转成没有播放状态图标
            obj.removeClass("fa-pause fa-2x");
            obj.addClass("fa-play-circle-o fa-3x");
        }
    }



    $(document).on('click', '.playicon', function () {
        var s = $(this).parent().find(".fa-play-circle-o").size();
        var ing = $(this).parent().find(".audiosrc").attr("isplaying");

        if (s > 0 && ing != 1) {
            status2play($(this), 1);
            play($(this).parent().find(".audiosrc").val());
        } else {
            status2play($(this), 0);

            if (ing == 1) {
                status2play($(this), 1);
                restore();
            }
            else {
                pause();
                $(this).parent().find(".audiosrc").attr("isplaying", 1);
            }
        }
    });

});