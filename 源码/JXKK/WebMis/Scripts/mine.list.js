$(function () {
    alert(111);
    //#region 定义对象
    var dataridMoel = function (ele, opt) {
        this.$ele = ele;
        var obj = this.$ele;

        //#region 按钮事件
        $(obj).find("a").each(function (index, item) {
            var Atext = $(item).text();
            if ($.trim(Atext) == "增加") {
                $(item).preventDefault();
            }
        });
        //#endregion
    };
});
