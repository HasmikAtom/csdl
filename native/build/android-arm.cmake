set(CMAKE_SYSTEM_NAME Android)

set(ANDROID_PLATFORM 21)
set(ANDROID_ABI armeabi-v7a)

set(CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER)

include($ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake)
include($ENV{ANDROID_NDK_HOME}/build/cmake/android.toolchain.cmake)
