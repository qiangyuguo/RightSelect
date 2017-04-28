__CreateJSPath = function(js){
	var scripts = document.getElementsByTagName("script");
	var path = "";
	for ( var i = 0, l = scripts.length; i < l; i++) {
		var src = scripts[i].src;
		if (src.indexOf(js) != -1) {
			var ss = src.split(js);
			path = ss[0];
			break;
		}
	}
	var href = location.href;
	href = href.split("#")[0];
	href = href.split("?")[0];
	var ss = href.split("/");
	ss.length = ss.length - 1;
	href = ss.join("/");
	if (path.indexOf("https:") == -1 && path.indexOf("http:") == -1
			&& path.indexOf("file:") == -1 && path.indexOf("\/") != 0) {
		path = href + "/" + path;
	}
	return path;
}

var bootPATH = __CreateJSPath("Scripts/common.js");

document.write('<link href="' + bootPATH
		+ 'Styles/themes/system.css" rel="stylesheet" type="text/css" />');
document.write('<script src="' + bootPATH
		+ 'Scripts/jquery-1.11.1.min.js" type="text/javascript"></sc' + 'ript>');
document.write('<script src="' + bootPATH
		+ 'Scripts/jquery.easyui.min.js" type="text/javascript" ></sc' + 'ript>');
document.write('<script src="' + bootPATH
		+ 'Scripts/json2.js" type="text/javascript"></sc' + 'ript>');
document.write('<script src="' + bootPATH
		+ 'Scripts/util.js" type="text/javascript"></sc' + 'ript>');
