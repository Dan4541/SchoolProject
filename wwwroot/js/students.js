// wwwroot/js/students.js

// Inicialización
document.addEventListener('DOMContentLoaded', function () {
    initializeStudentsPage();
});

function initializeStudentsPage() {
    // Mostrar fecha actual
    const dateElement = document.getElementById('currentDate');
    if (dateElement) {
        const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        const currentDate = new Date().toLocaleDateString('es-ES', options);
        dateElement.textContent = currentDate.charAt(0).toUpperCase() + currentDate.slice(1);
    }

    // Configurar fecha de matrícula por defecto (hoy)
    const enrollmentDateField = document.getElementById('EnrollmentDate');
    if (enrollmentDateField) {
        enrollmentDateField.valueAsDate = new Date();
    }

    // Configurar eventos para botones de editar
    document.querySelectorAll('.edit-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            editStudent(this);
        });
    });

    // Configurar eventos para botones de eliminar
    document.querySelectorAll('.delete-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            showDeleteConfirmation(this);
        });
    });

    // Limpiar formulario al abrir modal para nuevo estudiante
    const studentModal = document.getElementById('studentModal');
    if (studentModal) {
        studentModal.addEventListener('show.bs.modal', function (event) {
            // Si no se hizo clic en un botón de editar, resetear el formulario
            if (!event.relatedTarget || !event.relatedTarget.classList.contains('edit-btn')) {
                resetForm();
            }
        });
    }

    // Validación de formulario
    const studentForm = document.getElementById('studentForm');
    if (studentForm) {
        studentForm.addEventListener('submit', function (e) {
            if (!validateForm()) {
                e.preventDefault();
            }
        });
    }
}

// Mostrar confirmación para eliminar
function showDeleteConfirmation(button) {
    const studentId = button.getAttribute('data-id');
    const studentName = button.getAttribute('data-name');

    document.getElementById('studentNameToDelete').textContent = studentName;
    document.getElementById('deleteStudentId').value = studentId;

    const deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
    deleteModal.show();
}

// Editar estudiante
function editStudent(button) {
    // Llenar formulario con datos del estudiante
    document.getElementById('StudentId').value = button.getAttribute('data-id');
    document.getElementById('Code').value = button.getAttribute('data-code');
    document.getElementById('Name').value = button.getAttribute('data-name');
    document.getElementById('Lastname').value = button.getAttribute('data-lastname');
    document.getElementById('BirthDate').value = button.getAttribute('data-birthdate');
    document.getElementById('Gender').value = button.getAttribute('data-gender');
    document.getElementById('Address').value = button.getAttribute('data-address');
    document.getElementById('Phone').value = button.getAttribute('data-phone');
    document.getElementById('Email').value = button.getAttribute('data-email');
    document.getElementById('GuardianName').value = button.getAttribute('data-guardianname');
    document.getElementById('GuardianPhone').value = button.getAttribute('data-guardianphone');
    document.getElementById('EnrollmentDate').value = button.getAttribute('data-enrollmentdate');
    document.getElementById('IsActive').checked = button.getAttribute('data-isactive') === 'true';

    // Cambiar título del modal
    document.getElementById('studentModalLabel').innerHTML = '<i class="bi bi-pencil-fill"></i> Editar Estudiante';

    // Mostrar modal
    const studentModal = new bootstrap.Modal(document.getElementById('studentModal'));
    studentModal.show();
}

// Validar formulario
function validateForm() {
    const requiredFields = document.querySelectorAll('#studentForm [required]');
    let isValid = true;

    requiredFields.forEach(field => {
        if (!field.value.trim()) {
            field.classList.add('is-invalid');
            isValid = false;
        } else {
            field.classList.remove('is-invalid');
        }
    });

    // Validar email
    const emailField = document.getElementById('Email');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (emailField.value && !emailRegex.test(emailField.value)) {
        emailField.classList.add('is-invalid');
        isValid = false;
    }

    return isValid;
}

// Resetear formulario
function resetForm() {
    document.getElementById('studentForm').reset();
    document.getElementById('StudentId').value = '0';
    document.getElementById('studentModalLabel').innerHTML = '<i class="bi bi-person-plus-fill"></i> Nuevo Estudiante';

    const enrollmentDateField = document.getElementById('EnrollmentDate');
    if (enrollmentDateField) {
        enrollmentDateField.valueAsDate = new Date();
    }

    const isActiveField = document.getElementById('IsActive');
    if (isActiveField) {
        isActiveField.checked = true;
    }

    // Remover clases de validación
    document.querySelectorAll('.is-invalid').forEach(el => {
        el.classList.remove('is-invalid');
    });
}