$('#project-select-all').on('click', function () {
    // Check/uncheck all checkboxes in the table
    var that = this;
    var rows = table.rows({ 'search': 'applied' }).nodes();
    $('input[type="checkbox"]', rows).prop('checked', function (index, oldPropertice) {
        this.checked = that.checked;
        var elm = $(this).parents('tr');
        !this.checked ? elm.removeClass('selected') : elm.addClass('selected');
    });
});

// Handle click on checkbox to set state of "Select all" control
$('#project-data tbody').on('change', 'input[type="checkbox"]', function () {
    // If checkbox is not checked
    var elm = $(this).parents('tr');
    if (!this.checked) {
        var el = $('#project-select-all').get(0);
        // If "Select all" control is checked and has 'indeterminate' property
        if (el && el.checked && ('indeterminate' in el)) {
            // Set visual state of "Select all" control
            // as 'indeterminate'
            el.indeterminate = true;
        }

        elm.removeClass('selected');
    } else {
        elm.addClass('selected');
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
        "targets": 'nosort',
        "orderable": false,
        'searchable': false,
        "data": "active",
        "className": "dt-body-center"
    }],
    'order': [1, 'asc']
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

$('#confirm-delete').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var projectId = $(this).data('id');
    var url = $(this).data('url');
    if (projectId != 'all') {
        var ids = [projectId];
        $_post(url, { id: JSON.stringify(ids) }, $modalDiv, 'Deleting');
    } else {
        var ids = [];
        $('#project-data tbody input[type="checkbox"]:checked').each(function () { ids.push($(this).val()); });
        $_post(url,  { id: JSON.stringify(ids) }, $modalDiv, 'Deleting');
    }
});


// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-delete').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('#title', this).text(data.title);
    $('#submit', this).data({ id: data.id, url: data.url });
});


// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-add').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('#submit', this).data({ url: data.url });
});

$('#confirm-add').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var url = $(this).data('url');

    var startDate = $('#addDate').data('daterangepicker').startDate.format("DD/MM/YYYY h:mm A");
    var endDate = $('#addDate').data('daterangepicker').endDate.format("DD/MM/YYYY h:mm A");
    var title = $modalDiv.find('#title').val();
    $_post(url, { name: title, startDate: startDate, endDate: endDate }, $modalDiv, 'Adding');
});


// Bind to modal opening to set necessary data properties to be used to make request
$('#confirm-edit').on('show.bs.modal', function (e) {
    var data = $(e.relatedTarget).data();
    $('#title', this).text(data.title);
    $('#name', this).val(data.name);
    $('#editDate').data('daterangepicker').setStartDate(data.startDate);
    $('#editDate').data('daterangepicker').setEndDate(data.endDate);
    $('#submit', this).data({ url: data.url, id: data.id, name: data.name, createdBy: data.createdBy });
});

$('#confirm-edit').on('click', '#submit', function (e) {
    var $modalDiv = $(e.delegateTarget);
    var url = $(this).data('url');

    var startDate = $('#editDate').data('daterangepicker').startDate.format("DD/MM/YYYY h:mm A");
    var endDate = $('#editDate').data('daterangepicker').endDate.format("DD/MM/YYYY h:mm A");
    var name = $modalDiv.find('#name').val();
    var createdBy = $(this).data('createdBy');
    var id = $(this).data('id');
    $_post(url, { id: id, createdBy: createdBy, name: name, startDate: startDate, endDate: endDate }, $modalDiv, 'Updating');
});