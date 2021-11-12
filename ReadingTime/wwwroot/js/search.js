/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingTime.wwwroot.js
{
    public class search
    {
    }
}
*/
$(function () {
    $('from').submit(function (e) {
        e.preventDefault();

        var query = $('#query').val();
        $('tbody').load('/Books/Search?query=' + query);
    });
});