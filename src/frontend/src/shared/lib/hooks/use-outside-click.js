import {onMounted, onUnmounted, ref} from "vue";

export const useOutsideClick = () => {
    const active = ref(false);
    const elementRef = ref(null);

    const toggleActive = () => {
        active.value = !active.value;
    }

    const handleClick = (event) => {
        if (elementRef.value && !elementRef.value.contains(event.target)) {
            active.value = false;
        }
    };

    onMounted(() => {
        document.addEventListener("click", handleClick);
    });

    onUnmounted(() => {
        document.removeEventListener("click", handleClick);
    });

    return {elementRef, active, toggleActive};
}