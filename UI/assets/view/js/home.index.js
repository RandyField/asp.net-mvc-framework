//自动高度
function AutoHeight() {
    var h_page = document.documentElement.clientHeight || document.body.clientHeight;
    var h_navbar = $("#navbar").height();
    var h_footer = $(".footer-content").height();
    var h_breadcrumbs = $("#breadcrumbs").height();
    document.getElementById("right-iframe").style.height = (h_page - h_navbar - h_footer - h_breadcrumbs - 51) + "px";
}
window.onresize = function () {
    AutoHeight();
}
//加载
window.onload = function () {
    AutoHeight();
}


$(document).on('click', '[data-widget="async-iframe"]', function (event) {
    event.preventDefault();

    var $this = $(this),
        target = $this.attr('data-target') || '#right-iframe',
        href = $this.attr('href') || $this.attr('data-href') || $this.attr('data-src') || '/',
        $lis = $this.parents('ul').find('li'),
        menucode = $this.attr("data-code"),
        $li = $this.parents('li'); // 找到所有父级li标签
    $lis.removeClass('active');
    $li.addClass('active');

    $(target).attr('src', href + "?menucode=" + menucode + "");
});
