set(CMAKE_SYSTEM_NAME Windows)
set(CMAKE_SYSTEM_VERSION 10.0)
set(CMAKE_SYSTEM_PROCESSOR AMD64)
set(CMAKE_GENERATOR_PLATFORM AMD64 CACHE INTERNAL "")

set(VCPKG_TARGET_TRIPLET x64-windows-release)
include($ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake)
