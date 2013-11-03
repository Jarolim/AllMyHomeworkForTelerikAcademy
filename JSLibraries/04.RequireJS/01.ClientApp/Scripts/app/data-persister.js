/// <reference path="libs/class.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/require.js" />
/// <reference path="libs/rsvp.js" />

define(["httpRequester"], function (httpRequester) {
    function getStudents() {
        var url = this.url + "api/students/";
        return httpRequester.getJSON(url);
    }

    function getMarksByStudentId(studentId) {
        var url = this.url + "api/students/" + studentId + "/marks/";
        return httpRequester.getJSON(url);
    }

    return {
        students: getStudents,
        marks: getMarksByStudentId,
        url: this.url
    }
});