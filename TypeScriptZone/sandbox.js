function $true(x) {
    return function (y) { return x; };
}
function $false(x) {
    return function (y) { return y; };
}
function $if(c) {
    return c;
}
function and(a) {
    return function (b) { return a(b($true)($false))($false); };
}
function or(a) {
    return function (b) { return a($true)(b($true)($false)); };
}
function tuple(a) {
    return function (b) { return function (c) { return c(a)(b); }; };
}
function tup3(a) {
    return function (b) { return function (c) { return c(a)(b); }; };
}
var left = $true;
var right = $false;
var l = function (t) { return t($true); };
var r = function (t) { return t($false); };
var tmp = tuple("ABC")(10);
var res2 = r(tmp);
var res3 = l(tmp);
alert(tmp(right));
alert(r(tmp));
