interface Bool {
    <T>(x: T): (y: T) => T;
}
function $true<T, U>(x: T): (y: U) => T {
    return y => x;
}
function $false<T, U>(x: T): (y: U) => U {
    return y => y;
}
function $if(c: Bool) {
    return c;
}
function and(a: Bool): Bool {
    return (b: Bool) => a(b($true)($false))($false);
}
function or(a: Bool): Bool {
    return (b: Bool) => a($true)(b($true)($false));
}

//var x = $if(or($true)($false))(100)(3.14);

interface Tuple<T, U> {
    <V>(c: (a: T) => (b: U) => V): V;
}

function tuple<T>(a: T): <U>(b: U) => Tuple<T, U> {
    return b => c => c(a)(b);
}

function tup3<T, U>(a: T): (b: U) => Tuple<T, U> {
    return b => c => c(a)(b);
}

var left = $true;
var right = $false;
var l = <T, U>(t: Tuple<T, U>) => t<T>($true);
var r = <T, U>(t: Tuple<T, U>) => t<U>($false);

var tmp = tuple("ABC")(10);
var res2 = r(tmp);
var res3 = l(tmp);

alert(tmp(right));
alert(r(tmp));