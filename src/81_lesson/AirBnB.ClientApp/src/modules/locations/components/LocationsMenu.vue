<template>

 <!-- Locations menu -->
 <div class="flex items-center flex-grow gap-4 pl-6 pr-2 border rounded-full shadow-sm border-borderSecondary md:grow-0 md:w-fit hover:shadow-md">
            
    <!-- Locations menu detailed -->
    <div class="items-center justify-center hidden h-12 gap-5 md:flex">
        
        <button class="text-sm font-medium">
            <span class="line-clamp-1"> Anywhere</span>
        </button>

        <div class="border border-r-borderSecondary h-3/5"></div>

        <button class="text-sm font-medium">
            <span class="line-clamp-1">Any week</span>
        </button>

        <div class="border border-r-borderSecondary h-3/5"></div>

        <button class="flex items-center justify-center gap-3 text-sm text-textSecondary">
            <span class="line-clamp-1">
                Add Guests
            </span>
            
            <span class="bg-logoPrimary h-[32px] w-[32px] rounded-full text-white flex items-center justify-center">
                <svg xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 32 32"
                    aria-hidden="true"
                    role="presentation"
                    focusable="false"
                    style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
                    <path fill="none"
                        d="M13 24a11 11 0 1 0 0-22 11 11 0 0 0 0 22zm8-3 9 9"></path>
                </svg>
            </span>
        </button>
    </div>

    <!-- Location menu simple -->
    <button class="flex items-center justify-center h-12 gap-3 md:hidden">
        
        <span class="">
            <svg class="w-[20px] h-[20px] stroke-textPrimary stroke-[5px]"
                    width="20px" height="20px"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 32 32"
                    aria-hidden="true"
                    role="presentation"
                    focusable="false">
                <path fill="none"
                        d="M13 24a11 11 0 1 0 0-22 11 11 0 0 0 0 22zm8-3 9 9"></path>
            </svg>
        </span>

        <span class="flex flex-col items-start">
            <span class="text-sm font-medium">
                <span>Anywhere</span>
            </span>
            <span class="text-xs text-textSecondary">
                <span>Any week</span>
                <span>•</span>
                <span>Add guests</span>
            </span>
        </span>
        
    </button>
</div>

</template>