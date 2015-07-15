
var audio = new Audio();

function play(src) {
    audio.src = src;
    audio.play();
}

function pause() {
    audio.pause();
}

function restore()
{
    audio.play();
}

audio.addEventListener('ended', function () {
    
}, false);