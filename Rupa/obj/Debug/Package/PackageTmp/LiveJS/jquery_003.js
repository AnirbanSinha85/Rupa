// Generated by CoffeeScript 1.6.1
/*
	FlexNav.js 0.5.2

	Copyright 2013, Jason Weaver http://jasonweaver.name
	Released under the WTFPL license
	http://sam.zoy.org/wtfpl/

//
*/(function(){var e=[].indexOf||function(e){for(var t=0,n=this.length;t<n;t++)if(t in this&&this[t]===e)return t;return-1};$.fn.flexNav=function(t){var n,r,i,s,o,u,a,f,l;l=$.extend({animationSpeed:"fast"},t,n=$(this),n.data("breakpoint")?s=n.data("breakpoint"):void 0,n.data("breakpoint-em")?(u="<div class='hidden-text'>M and FlexNav</div>",$("body").append(u),r=$(".hidden-text"),r.css({display:"inline-block",padding:"0","line-height":"1",position:"absolute",visibility:"hidden","font-size":"1em"}),o=n.data("breakpoint-em"),i=r.css("font-size"),s=o*parseInt(i),console.log(s),r.remove()):void 0,f=function(){if($(window).width()<=s){n.removeClass("lg-screen").addClass("sm-screen");$(".sm-screen.one-page li a").on("click",function(){return n.removeClass("show")});return $(".item-with-ul").off()}n.removeClass("sm-screen").addClass("lg-screen");n.removeClass("show");return $(".item-with-ul").on({mouseenter:function(){return $(this).find(">ul").slideDown(l.animationSpeed)},mouseleave:function(){return $(this).find(">ul").slideUp(l.animationSpeed)}})},a=function(){return e.call(window,"ontouchstart")>=0},a()?n.addClass("flexNav-touch"):n.addClass("flexNav-no-touch"),$(this).find("li").each(function(){if($(this).has("ul").length)return $(this).addClass("item-with-ul")}),$(".menu-button").on("click",function(){return n.toggleClass("show")}),$(".menu-button, .item-with-ul").append('<span class="touch-button"><img src="images/bullet.png"></span>'),$(".touch-button").on("click",function(){return $(this).parent(".item-with-ul").find(">ul").slideToggle(l.animationSpeed)}),$(".item-with-ul *").focus(function(){$(this).parent(".item-with-ul").parent().find(".open").not(this).hide().removeClass("open");return $(this).parent(".item-with-ul").find(">ul").addClass("open").show()}));f();return $(window).on("resize",f)}}).call(this);