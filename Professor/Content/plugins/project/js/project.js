$('#project-select-all').on('click', function () {
    // Check/uncheck all checkboxes in the table
    var rows = table.rows({ 'search': 'applied' }).nodes();
    $('input[type="checkbox"]', rows).prop('checked', this.checked);
});

// Handle click on checkbox to set state of "Select all" control
$('#project-data tbody').on('change', 'input[type="checkbox"]', function () {
    // If checkbox is not checked
    if (!this.checked) {
        var el = $('#project-select-all').get(0);
        // If "Select all" control is checked and has 'indeterminate' property
        if (el && el.checked && ('indeterminate' in el)) {
            // Set visual state of "Select all" control
            // as 'indeterminate'
            el.indeterminate = true;
        }
    }
});
var table = $('#project-data').DataTable({
    "paging": true,
    "lengthChange": true,
    "searching": true,
    "ordering": true,
    "info": true,
    "autoWidth": true,
    "visible": true,
    "columnDefs": [{
        "targets": 'no-sort',
        "orderable": false,
        'searchable': true,
        data: "active",
        className: "dt-body-center"
    },
    {
        "targets": 4,
        "orderable": false,
        'searchable': false,
    }],
    'order': [1, 'asc']
});

$('#confirm-delete').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var id = $(this).data('id');
    var url = $(this).data('url');
    $modalDiv.addClass('loading');
    $.post(url, { id: id }, function (msg) {
        if (msg) {
            setTimeout(function () {
                $modalDiv.find('.modal-content').attr('data-error', msg);
                $modalDiv.removeClass('loading');
            }, 2000);
            $modalDiv.addClass('err');
            setTimeout(function () {
                $modalDiv.removeClass('err');
            }, 3000);
        } else location.reload();
    });
});


// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-delete').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('#title', this).text(data.title);
    $('#submit', this).data({ id: data.id, url: data.url });
});