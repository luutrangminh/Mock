var table = $('#project-data').DataTable({
    "paging": true,
    "lengthChange": true,
    "searching": true,
    "ordering": true,
    "info": true,
    "autoWidth": true,
    "visible": true,
    "columnDefs": [{
        "targets": ['nosort', 'no-sort'],
        "orderable": false,
        'searchable': false,
    }],
    'order': [5, 'asc']
});

var table2 = $('#student-data').DataTable({
    "paging": true,
    "lengthChange": true,
    "searching": true,
    "ordering": true,
    "info": true,
    "autoWidth": true,
    "visible": true,
    "columnDefs": [{
        "targets": ['nosort', 'no-sort'],
        "orderable": false,
        'searchable': false,
    }],
    'order': [1, 'asc']
});

$('#project-data tbody').on('click', 'tr', function () {
    if ($(this).hasClass('project-selected')) {
        $(this).removeClass('project-selected');
    }
    else {
        table.$('tr.project-selected').removeClass('project-selected');
        $(this).addClass('project-selected');

    }
});

function $_post(url, data, $modalDiv, postMsg) {
    $modalDiv.find('.modal-content').attr('data-msg', postMsg);
    $modalDiv.addClass('loading');
    $.post(url, data, function (msg) {
        if (msg) {
            setTimeout(function () {
                $modalDiv.find('.modal-content').attr('data-error', msg);
                $modalDiv.removeClass('loading');
            }, 2000);
            $modalDiv.addClass('err');
            setTimeout(function () {
                $modalDiv.removeClass('err');
            }, 5000);
        }
        else window.location.reload();
    });
} 

// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-projects').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('#submit', this).data({ url: data.url, title: data.title });
});

$('#confirm-projects').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var url = $(this).data('url');
    var title = $(this).data('title');
    if (!table.row('.project-selected').data()) {
        $modalDiv.find('.modal-content').attr('data-msg', 'Chose a project. Please try again!');
        $modalDiv.addClass('loading');
        setTimeout(function () {
            $modalDiv.removeClass('loading');
        }, 2000);
    }
    var status = table.row('.project-selected').data()[5];
    if (status.toLowerCase() == '<span style="color: #ff0000;">closed</span>') {
        $modalDiv.find('.modal-content').attr('data-msg', 'Project is closed');
        $modalDiv.addClass('loading');
        setTimeout(function () {
            $modalDiv.removeClass('loading');
        }, 2000);
    } else {
        var projectCode = table.row('.project-selected').data()[0];
        $(this).attr({ 'data-title': title, 'data-url': url, 'data-project-code': projectCode });
        $('#confirm-assign').modal('toggle');
    }
});

// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-assign').on('show.bs.modal', function (e) {
    var $data = $('#confirm-projects #submit');
    var title = $data.attr('data-title');
    var projectCode = $data.attr('data-project-code');
    var url = $data.attr('data-url');
    $('#title', this).text(title);
    $('#projectCode', this).text(projectCode);
    $('#submit', this).data({ url: url, 'project-code': projectCode });
});

$('#confirm-assign').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var url = $(this).data('url');
    var projectCode = $(this).data('projectCode');
    $_post(url, { projectCode: projectCode }, $modalDiv, 'Assigning');
});