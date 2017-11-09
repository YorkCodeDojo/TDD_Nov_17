cmake_minimum_required(VERSION 3.1)

set (CMAKE_CXX_STANDARD 14)
set (CMAKE_EXPORT_COMPILE_COMMANDS ON)

PROJECT (Dojo)

MESSAGE(STATUS " CMakeLists: Dojo")

SET_PROPERTY(GLOBAL PROPERTY USE_FOLDERS ON)

# global needed variables
SET (APPLICATION_NAME "Dojo")
SET (APPLICATION_VERSION_MAJOR "0")
SET (APPLICATION_VERSION_MINOR "1")
SET (APPLICATION_VERSION_PATCH "0")
SET (APPLICATION_VERSION "${APPLICATION_VERSION_MAJOR}.${APPLICATION_VERSION_MINOR}.${APPLICATION_VERSION_PATCH}")

# Set all compiler flags 
INCLUDE(cmake/all.cmake)
INCLUDE(cmake/copy_files.cmake)
INCLUDE(m3rdparty/list.cmake)

# config_app.h checks
# This makes a config_shared.h file which can be included for system settings
#  Must be after setting up the platforms
CONFIGURE_FILE(${CMAKE_CURRENT_LIST_DIR}/cmake/config_app.h.cmake ${CMAKE_BINARY_DIR}/config_app.h)

INCLUDE_DIRECTORIES(
    src
    .
    ${M3RDPARTY_INCLUDE}
    ) 

SET (DOJO_SOURCE src/words.cpp)

# Create the library - No depenencies on anything else in this file
ADD_LIBRARY(DojoLib STATIC ${DOJO_SOURCE})

# Demo
ADD_EXECUTABLE (${PROJECT_NAME} main.cpp)
copy_existing_files(${PROJECT_NAME} words.txt ${CMAKE_CURRENT_BINARY_DIR}/$(Configuration) )
TARGET_LINK_LIBRARIES (${PROJECT_NAME} DojoLib ${PLATFORM_LINKLIBS})

# Unit Tests
INCLUDE(tests/list.cmake)
enable_testing()
SET(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -DGTEST_HAS_TR1_TUPLE=0")
SET (TEST_SOURCES
    ${M3RDPARTY_DIR}/googletest/googletest/src/gtest-all.cc
    ${TEST_SOURCES}
)
ADD_EXECUTABLE (unittests ${TEST_SOURCES} )
TARGET_LINK_LIBRARIES (unittests DojoLib ${PLATFORM_LINKLIBS} ${CMAKE_THREAD_LIBS_INIT})
add_test(unittests unittests)

SOURCE_GROUP (Dojo REGULAR_EXPRESSION "src/.*")
