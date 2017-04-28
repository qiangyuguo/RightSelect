//pagination
if ($.fn.pagination){
	jQuery.extend($.fn.pagination.defaults,{  
	    beforePageText:"第",  
	    afterPageText:"页 共{pages}页",
	    displayMsg:"显示:第{from}-{to}条,共{total}条记录"//&nbsp;&nbsp;&nbsp;"  
	});
}

//datagrid
if ($.fn.datagrid){
	jQuery.extend($.fn.datagrid.defaults,{  
	    loadMsg:"正在处理，请等待...",
	    singleSelect:true,
		nowrap: false,
		striped: true,
		remoteSort: false,
		pagination: true,
		fit: true,
		fitColumns:true,
		pageSize: 15,
		pageList:[15,20,25,30,35,40,45,50],
		rowStyler: function(index,row){
			return 'height: 22px;';
		},
		onLoadSuccess:function(data){
		    $.SuccessCheck(data); //成功检查
		},
		onLoadError:function(){
		    $.messager.alert("错误提示","表格信息加载失败","error");
		}
	});
}

//messager
if ($.messager){
	jQuery.extend($.messager.defaults,{  
	    ok:"确定",  
	    cancel:"取消"  
	});
}

//validatebox
if ($.fn.validatebox){
	$.fn.validatebox.defaults.missingMessage='必输项',
	$.fn.validatebox.defaults.rules.email.message = '请输入有效的Email';
	$.fn.validatebox.defaults.rules.url.message = '请输入有效的URL地址';
	$.fn.validatebox.defaults.rules.length.message = '输入内容长度必须介于{0}和{1}之间';
	$.fn.validatebox.defaults.rules.remote.message = '请修正该字段';
	$.extend($.fn.validatebox.defaults.rules, {
	    date: {  
	        validator: function(value){
	            return value.match(/((^((1[8-9]\d{2})|([2-9]\d{3}))(-)(10|12|0[13578])(-)(3[01]|[12][0-9]|0[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(11|0[469])(-)(30|[12][0-9]|0[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(02)(-)(2[0-8]|1[0-9]|0[1-9])$)|(^([2468][048]00)(-)(02)(-)(29)$)|(^([3579][26]00)(-)(02)(-)(29)$)|(^([1][89][0][48])(-)(02)(-)(29)$)|(^([2-9][0-9][0][48])(-)(02)(-)(29)$)|(^([1][89][2468][048])(-)(02)(-)(29)$)|(^([2-9][0-9][2468][048])(-)(02)(-)(29)$)|(^([1][89][13579][26])(-)(02)(-)(29)$)|(^([2-9][0-9][13579][26])(-)(02)(-)(29)$))/);
	        },  
	        message: '日期格式需为YYYY-MM-DD'
	    },
	    equals: {  
	        validator: function(value,param){  
	            return value == $(param[0]).val();  
	        },  
	        message: '输入不一致'  
	    } 
	});
}

//numberbox
if ($.fn.numberbox){
	$.fn.numberbox.defaults.missingMessage = '必输项';
}

//combobox
jQuery.extend($.fn.combobox.defaults,{  
	missingMessage:'必输项',
    editable:false,
    onLoadSuccess:function(data){
		$.SuccessCheck(data);//成功检查
	},
	onLoadError:function(){
	    $.messager.alert("错误提示","下拉列表数据加载失败","error");
	}
});

//combotree
if ($.fn.combotree){
	$.fn.combotree.defaults.missingMessage = '必输项';
}

//combogrid
if ($.fn.combogrid){
	$.fn.combogrid.defaults.missingMessage = '必输项';
}

//calendar
if ($.fn.calendar){
	$.fn.calendar.defaults.weeks = ['日','一','二','三','四','五','六'];
	$.fn.calendar.defaults.months = ['一月','二月','三月','四月','五月','六月','七月','八月','九月','十月','十一月','十二月'];
}

//datebox
jQuery.extend($.fn.datebox.defaults,{
	missingMessage:'必输项',
	currentText:"今天",
	closeText:"关闭",
	okText: "确定"
//    ,
//	formatter:function(date){
//	    var y = date.getFullYear();
//	    var m = date.getMonth() + 1;
//	    var d = date.getDate();
//	    return y + '-' + (m < 10 ? '0' + m : m) + '-' + (d < 10 ? '0' + d : d);
//	}
});

//panel
jQuery.extend($.fn.panel.defaults,{  
	loadingMessage:"正在加载页面..."
});

//window
jQuery.extend($.fn.window.defaults,{
	collapsible:false,
	minimizable:false,
	maximizable:false,
	modal:true,
	resizable:false
});



//form
jQuery.extend($.fn.form.defaults,{  
	onLoadSuccess:function(data){
		$.SuccessCheck(data);//成功检查
	},
	onLoadError:function(){
		$.messager.alert("错误提示","窗体信息加载失败","error");
	},
	onSubmit:function(){
		return $(this).form('validate');
    }
});

//tree
jQuery.extend($.fn.tree.defaults,{  
	onLoadSuccess:function(node, data){
		$.SuccessCheck(data);//成功检查
	},
	onLoadError:function(){
	    $.messager.alert("错误提示","树结构信息加载失败","error");
	}
});

var iTipNum = 0;
jQuery.extend({
    SuccessCheck:function(data){
    	if(data != undefined && data.messageType!=undefined &&  data.messageType!=0){//错误
        	if(data.messageType==1){
	            $.messager.alert("错误提示",data.message,"error");
	            data=null;
	            return false;
        	}
	        else if(data.messageType==2){//权限检查错误
	            iTipNum++;
	            if(iTipNum > 1)
	                return;
	             $.messager.alert("错误提示",data.message,"error",function(){
	                iTipNum = 0;
	                window.parent.location.href=window.parent.location.href.toLowerCase().replace('main.htm','login.htm');
                });
	            data=null;
	            return false;
	        }
        }
        else
            return true;
    },
    ClientSuccessCheck:function(data){
    	if(data != undefined && data.messageType!=undefined &&  data.messageType!=0){//错误
        	if(data.messageType==1){
	            $.messager.alert("错误提示",data.message,"error");
	            data=null;
	            return false;
        	}
	        else if(data.messageType==2){//权限检查错误
	            iTipNum++;
	            if(iTipNum > 1)
	                return;
	             $.messager.alert("错误提示",data.message,"error",function(){
	                iTipNum = 0;
	                window.parent.location.href=window.parent.location.href.toLowerCase().replace('main.htm','login.htm');
                });
	            data=null;
	            return false;
	        }
        }
        else
            return true;
    }
});

jQuery.extend({
	request:function(paras){ 
        var url = location.href; 
        var paraString = url.substring(url.indexOf("?")+1,url.length).split("&"); 
        var paraObj = {} 
        for (i=0; j=paraString[i]; i++){ 
        paraObj[j.substring(0,j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=")+1,j.length); 
        } 
        var returnValue = paraObj[paras.toLowerCase()]; 
        if(typeof(returnValue)=="undefined"){ 
        return ""; 
        }else{ 
        return returnValue; 
        } 
    }
});


Date.prototype.format = function(format){
    var o ={
        "M+" : this.getMonth()+1, //month
        "d+" : this.getDate(),    //day
        "h+" : this.getHours(),   //hour
        "m+" : this.getMinutes(), //minute
        "s+" : this.getSeconds(), //second
        "q+" : Math.floor((this.getMonth()+3)/3),  //quarter
        "S" : this.getMilliseconds() //millisecond
    }
    if(/(y+)/.test(format))
    	format=format.replace(RegExp.$1,(this.getFullYear()+"").substr(4 - RegExp.$1.length));
    for(var k in o)
    	if(new RegExp("("+ k +")").test(format))
    		format = format.replace(RegExp.$1,RegExp.$1.length==1 ? o[k] : ("00"+ o[k]).substr((""+ o[k]).length));
    return format;
}

String.prototype.validateDate = function(){
	return this.match(/((^((1[8-9]\d{2})|([2-9]\d{3}))(-)(10|12|0[13578])(-)(3[01]|[12][0-9]|0[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(11|0[469])(-)(30|[12][0-9]|0[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(02)(-)(2[0-8]|1[0-9]|0[1-9])$)|(^([2468][048]00)(-)(02)(-)(29)$)|(^([3579][26]00)(-)(02)(-)(29)$)|(^([1][89][0][48])(-)(02)(-)(29)$)|(^([2-9][0-9][0][48])(-)(02)(-)(29)$)|(^([1][89][2468][048])(-)(02)(-)(29)$)|(^([2-9][0-9][2468][048])(-)(02)(-)(29)$)|(^([1][89][13579][26])(-)(02)(-)(29)$)|(^([2-9][0-9][13579][26])(-)(02)(-)(29)$))/);
}

String.prototype.validateYM = function(){
	return this.match(/^((1[8-9]\d{2})|([2-9]\d{3}))(0[1-9]|1[0-2])$/);
}

//------------------格式化时间为 yyyy-MM-dd ---------------------------------------
$.fn.datebox.defaults.formatter = function (date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? '0' + m : m) + '-' + (d < 10 ? '0' + d : d);
};
//
$.fn.datebox.defaults.parser = function (s) {
    if (s) {
        var a = s.split('-');
        var d = new Date(parseInt(a[0]), parseInt(a[1]) - 1, parseInt(a[2]));
        return d;
    } else {
        return new Date();
    }

};

