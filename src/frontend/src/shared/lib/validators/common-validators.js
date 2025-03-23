const Validate = (value) => {
    if (value === undefined || value === null) {
        return "This field is required.";
    }
}
const ValidateText = (value) => {
    if (!value || value.trim().length < 1) {
        return "This field is required.";
    }
}
const ValidateEmail = (value) => {
    if (!value){
        return "Email field cannot be empty.";
    }

    if (!value.includes("@")){
        return "Email must contain '@'.";
    }

    if ((value.match(/@/g) || []).length > 1){
        return "Email cannot contain multiple '@' symbols.";
    }

    if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(value)) {
        return "Please enter a valid email address.";
    }
}

const ValidateOptions = (value) => {
    if (Validate(value)) {
        return "Please select an option.";
    }
}

const ValidateMultipleOptions = (value) => {
    if (Validate(value) || value.length < 1){
        return "Please select at least one option.";
    }
}

const ValidateDate = (value) => {
    const error = Validate(value);
    if (error){
        return error;
    }

    if (isNaN(value)){
        return "Invalid date format.";
    }
}
const ValidateBirthDate = (value) => {
    const error = ValidateDate(value);
    if (error){
        return error;
    }
    const today = new Date();
    if (value > today){
        return "Marty, you can't be born in the future! Time travel's tricky!"
    }
}

export const COMMON_VALIDATORS = {
    none: {
        check: () => undefined,
    },
    default: {
        check: Validate
    },
    text: {
        check: ValidateText
    },
    date: {
        check: ValidateDate,
    },
    email: {
        helperText: "Enter a valid email address (e.g., name@example.com)",
        check: ValidateEmail
    },
    birthdate: {
        check: ValidateBirthDate
    },
    radio: {
        check: ValidateOptions,
    },
    checkbox: {
        check: ValidateMultipleOptions
    }
}